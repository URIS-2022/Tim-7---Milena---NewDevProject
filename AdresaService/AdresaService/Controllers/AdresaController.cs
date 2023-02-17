using AdresaService.Entities;
using AdresaService.Models;
using AdresaService.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdresaService.Controllers
{
    [ApiController]
    [Route("api/adresa")]
    public class AdresaController : ControllerBase
    {
        private readonly IAdresaRepository adresaRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public AdresaController(IAdresaRepository adresaRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.adresaRepository = adresaRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Vraca sve adrese
        /// </summary>
        /// <returns> Lista adresa </returns>
        /// <response code="200">Vraca adrese</response>
        /// <response code="404">Ne postoji nijedna adrese</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<AdresaDTO>> GetAdrese()
        {
            List<Adresa> adrese = adresaRepository.GetAdrese();
            if (adrese == null || adrese.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<AdresaDTO>>(adrese));
        }

        /// <summary>
        /// Vraca jednu adresu na osnovu ID.
        /// </summary>
        /// <param name="adresaID">ID adrese</param>
        /// <returns>Odgovarajuca adresa</returns>
        /// <response code="200">Vraća trazenu adresu</response>
        /// <response code="404">Nije pronadjena tražena adresa</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{adresaID}")]
        public ActionResult<AdresaDTO> GetAdresaByID(Guid adresaID)
        {
            var adresa = adresaRepository.GetAdresa(adresaID);
            if (adresa == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<AdresaDTO>(adresa));

        }

        /// <summary>
        /// Kreira novu adresu.
        /// </summary>
        
        /// <response code="201">Vraća kreiranu adresu</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja adrese</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AdresaConfirmationDTO> CreateAdresa([FromBody] AdresaCreationDTO adresa)
        {
            try
            {
                var z = mapper.Map<Adresa>(adresa);
                Adresa confirmation = adresaRepository.CreateAdresa(z);
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string location = linkGenerator.GetPathByAction("GetAdrese", "Adresa", new { AdresaID = z.AdresaID });
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                #pragma warning disable CS8604 // Possible null reference argument.
                return Created(location, mapper.Map<AdresaConfirmationDTO>(confirmation));
                #pragma warning restore CS8604 // Possible null reference argument.
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja adrese!");
            }
        }

        /// <summary>
        /// Vrši brisanje adrese na osnovu ID-ja .
        /// </summary>
        /// <param name="adresaID">ID adrese</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">adresa uspešno obrisana</response>
        /// <response code="404">Nije pronađena adresa za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja adresa</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{adresaID}")]
        public IActionResult DeleteAdresa(Guid adresaID)
        {
            try
            {
                var adresa = adresaRepository.GetAdresa(adresaID);

                if (adresa == null)
                {
                    return NotFound();
                }

                adresaRepository.DeleteAdresa(adresaID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja adrese");
            }
        }

        /// <summary>
        /// Ažurira jednu adresu
        /// </summary>
        /// <returns>Potvrda o modfikovanoj adresi</returns>
        /// <response code="200">Vraća kreiranu adresu</response>
        /// <response code="400">adresa koja se želi ažurirati nije pronađena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja adrese</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AdresaUpdateDTO> UpdateAdresa([FromBody] AdresaUpdateDTO adresa)
        {

            try
            {
                Adresa staraAdresa = adresaRepository.GetAdresa(adresa.AdresaID);
                if (staraAdresa == null)
                {
                    return NotFound();
                }
                Adresa novaAdresa = mapper.Map<Adresa>(adresa);
                adresaRepository.UpdateAdresa(staraAdresa, novaAdresa);
                return Ok(mapper.Map<AdresaUpdateDTO>(novaAdresa));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja adrese!");
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa adresom
        /// </summary>
        [HttpOptions]
        public IActionResult GetAdresaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }




























    }
}
