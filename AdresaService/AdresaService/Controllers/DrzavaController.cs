using AdresaService.Entities;
using AdresaService.Models;
using AdresaService.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdresaService.Controllers
{
    [ApiController]
    [Route("api/drzava")]
    public class DrzavaController : ControllerBase
    {
        private readonly IDrzavaRepository drzavaRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public DrzavaController(IDrzavaRepository drzavaRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.drzavaRepository = drzavaRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Vraca sve drzave
        /// </summary>
        /// <returns> Lista drzava </returns>
        /// <response code="200">Vraca drzave</response>
        /// <response code="404">Ne postoji nijedna drzava</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<DrzavaDTO>> GetDrzave()
        {
            List<Drzava> drzave = drzavaRepository.GetDrzave();
            if (drzave == null || drzave.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<DrzavaDTO>>(drzave));
        }

        /// <summary>
        /// Vraca jednu drzavu na osnovu ID.
        /// </summary>
        /// <param name="drzavaID">ID drzave</param>
        /// <returns>Odgovarajuca drzava</returns>
        /// <response code="200">Vraća trazenu drzavu</response>
        /// <response code="404">Nije pronadjena tražena drzava</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{drzavaID}")]
        public ActionResult<DrzavaDTO> GetDrzavaByID(Guid drzavaID)
        {
            var drzava = drzavaRepository.GetDrzava(drzavaID);
            if (drzava == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DrzavaDTO>(drzava));

        }

        /// <summary>
        /// Kreira novu drzavu.
        /// </summary>
        
        /// <response code="201">Vraća kreiranu drzavu</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja drzave</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DrzavaConfirmationDTO> CreateDrzava([FromBody] DrzavaCreationDTO drzava)
        {
            try
            {
                var z = mapper.Map<Drzava>(drzava);
                Drzava confirmation = drzavaRepository.CreateDrzava(z);
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string location = linkGenerator.GetPathByAction("GetDrzave", "Drzava", new { DrzavaID = z.DrzavaID });
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                #pragma warning disable CS8604 // Possible null reference argument.
                return Created(location, mapper.Map<DrzavaConfirmationDTO>(confirmation));
                #pragma warning disable CS8604 // Possible null reference argument.
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja drzave!");
            }
        }

        /// <summary>
        /// Vrši brisanje drzave na osnovu ID-ja .
        /// </summary>
        /// <param name="drzavaID">ID drzave</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">drzava uspešno obrisana</response>
        /// <response code="404">Nije pronađena drzava za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja drzave</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{drzavaID}")]
        public IActionResult DeleteDrzava(Guid drzavaID)
        {
            try
            {
                var drzava = drzavaRepository.GetDrzava(drzavaID);

                if (drzava == null)
                {
                    return NotFound();
                }

                drzavaRepository.DeleteDrzava(drzavaID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom drzave");
            }
        }

        /// <summary>
        /// Ažurira jednu drzavu
        /// </summary>
        /// <returns>Potvrda o modfikovanoj drzavi</returns>
        /// <response code="200">Vraća kreiranu drzavu</response>
        /// <response code="400">drzava koja se želi ažurirati nije pronađena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja drzava</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DrzavaUpdateDTO> UpdateDrzava([FromBody] DrzavaUpdateDTO drzava)
        {

            try
            {
                Drzava staraDrzava = drzavaRepository.GetDrzava(drzava.DrzavaID);
                if (staraDrzava == null)
                {
                    return NotFound();
                }
                Drzava novaDrzava = mapper.Map<Drzava>(drzava);
                drzavaRepository.UpdateDrzava(staraDrzava, novaDrzava);
                return Ok(mapper.Map<DrzavaUpdateDTO>(novaDrzava));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja drzave!");
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa drzavom
        /// </summary>
        [HttpOptions]
        public IActionResult GetDrzavaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }





    }
}
