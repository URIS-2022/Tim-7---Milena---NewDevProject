using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UgovorService.Entities;
using UgovorService.Models;
using UgovorService.Repositories;

namespace UgovorService.Controllers
{
    [ApiController]
    [Route("api/tipgarancije")]
    public class TipGarancijeController : ControllerBase
    {
        private readonly ITipGarancijeRepository tipGarancijeRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        public TipGarancijeController(ITipGarancijeRepository tipGarancijeRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.tipGarancijeRepository = tipGarancijeRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Vraca sve tipove garancije
        /// </summary>
        /// <returns> Lista garancija </returns>
        /// <response code="200">Vraca listu garancija</response>
        /// <response code="404">Ne postoji nijedna garancija</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<TipGarancijeDto>> GetTipoveGarancija()
        {
            List<TipGarancije> tipoviGarancija = tipGarancijeRepository.GetTipoveGarancija();
            if (tipoviGarancija == null || tipoviGarancija.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<TipGarancijeDto>>(tipoviGarancija));
        }

        /// <summary>
        /// Vraca jednu garanciju na osnovu ID-ja garancije.
        /// </summary>
        /// <param name="tipGarancijeID">ID garancije</param>
        /// <returns>Odgovarajuca garancija</returns>
        /// <response code="200">Vraća trazenu garanciju</response>
        /// <response code="404">Nije pronadjena tražena garancija</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{tipGarancijeID}")]
        public ActionResult<TipGarancijeDto> GetTipGarancijeByID(Guid tipGarancijeID)
        {
            var tipGarancije = tipGarancijeRepository.GetTipGarancije(tipGarancijeID);
            if (tipGarancije == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TipGarancijeDto>(tipGarancije));

        }

        /// <summary>
        /// Kreira novi tip garancije.
        /// </summary>
        
        /// <response code="201">Vraća kreirani tip garancije</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja tipa garancije</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipGarancijeConfirmationDto> CreateTipGarancije([FromBody] TipGarancijeCreationDto tipGarancije)
        {
            try
            {
                var z = mapper.Map<TipGarancije>(tipGarancije);
                TipGarancije confirmation = tipGarancijeRepository.CreateTipGarancije(z);
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                string location = linkGenerator.GetPathByAction("GetTipoveGarancija", "TipGarancije", new { TipGarancijeID = z.TipGarancijeID });
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                #pragma warning disable CS8604 // Possible null reference argument.
                return Created(location, mapper.Map<TipGarancijeConfirmationDto>(confirmation));
                #pragma warning disable CS8604 // Possible null reference argument.
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja tipa garancije!");
            }
        }

        /// <summary>
        /// Vrši brisanje jednog tipa garancije na osnovu ID-ja tipa garancije.
        /// </summary>
        /// <param name="tipGarancijeID">ID tipa garancije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Garancija uspešno obrisana</response>
        /// <response code="404">Nije pronađena garancija za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja garancijee</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{tipGarancijeID}")]
        public IActionResult DeleteTipGarancije(Guid tipGarancijeID)
        {
            try
            {
                var tipGarancije = tipGarancijeRepository.GetTipGarancije(tipGarancijeID);

                if (tipGarancije == null)
                {
                    return NotFound();
                }

                tipGarancijeRepository.DeleteTipGarancije(tipGarancijeID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja garancije");
            }
        }

        /// <summary>
        /// Ažurira jednu garanciju
        /// </summary>
        /// <returns>Potvrda o modfikovanoj garanciji</returns>
        /// <response code="200">Vraća kreiranu garanciju</response>
        /// <response code="400">Garancija koja se želi ažurirati nije pronađena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja garancije</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipGarancijeUpdateDto> UpdateTipGarancije([FromBody] TipGarancijeUpdateDto tipGarancije)
        {

            try
            {
                TipGarancije stariTipGarancije = tipGarancijeRepository.GetTipGarancije(tipGarancije.TipGarancijeID);
                if (stariTipGarancije == null)
                {
                    return NotFound();
                }
                TipGarancije noviTipGarancije = mapper.Map<TipGarancije>(tipGarancije);
                tipGarancijeRepository.UpdateTipGarancije(stariTipGarancije, noviTipGarancije);
                return Ok(mapper.Map<TipGarancijeUpdateDto>(noviTipGarancije));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja tipa garancije!");
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa garancijom
        /// </summary>
        [HttpOptions]
        public IActionResult GetTipGarancijeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }




    }


}