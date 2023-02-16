using AutoMapper;
using JavnoNadmetanjeService.Models;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JavnoNadmetanjeService.Controllers
{
    [ApiController]
    [Route("api/tipJavnogNadmetanja")]
    public class TipJavnogNadmetanjaController:ControllerBase
    {
        private readonly ITipJavnogNadmetanjaRepository tipJavnogNadmetanjaRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public TipJavnogNadmetanjaController(ITipJavnogNadmetanjaRepository tipJavnogNadmetanjaRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.tipJavnogNadmetanjaRepository = tipJavnogNadmetanjaRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }
        /// <summary>
        /// Vraca sve tipove javnih nadmetanja
        /// </summary>
        /// <returns> Lista tipova javnih nadmetanja </returns>
        /// <response code="200">Vraca listu tipova javnih nadmetanja</response>
        /// <response code="404">Ne postoji nijedan tip javnih nadmetanja</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<TipJavnogNadmetanjaDTO>> GetTipoviJavnogNadmetanja()
        {
            List<TipJavnogNadmetanja> tipoviJavnogNadmetanja = tipJavnogNadmetanjaRepository.GetTipoviJavnogNadmetanja();
            if (tipoviJavnogNadmetanja == null || tipoviJavnogNadmetanja.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<TipJavnogNadmetanjaDTO>>(tipoviJavnogNadmetanja));
        }

        /// <summary>
        /// Vraca jedan tip javnih nadmetanja na osnovu ID-ja tipa javnog nadmetanja.
        /// </summary>
        /// <param name="tipJavnogNadmetanjaID">ID tipa javnog nadmetanja</param>
        /// <returns>Odgovarajući tip javnog nadmetanja</returns>
        /// <response code="200">Vraća traženi tip javnog nadmetanja</response>
        /// <response code="404">Nije pronadjen traženi tip javnog nadmetanja</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{tipJavnogNadmetanjaID}")]
        public ActionResult<TipJavnogNadmetanjaDTO> GetTipJavnogNadmetanjaByID(Guid tipJavnogNadmetanjaID)
        {
            var tipJavnogNadmetanja = tipJavnogNadmetanjaRepository.GetTipJavnogNadmetanja(tipJavnogNadmetanjaID);
            if (tipJavnogNadmetanja == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TipJavnogNadmetanjaDTO>(tipJavnogNadmetanja));

        }
        /// <summary>
        /// Kreira novi tip javnog nadmetanja.
        /// </summary>
        /// </remarks>
        /// <response code="201">Vraća kreirani tip javnog nadmetanja</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja tipa javnog nadmetanja</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipJavnogNadmetanjaDTO> CreateTipJavnogNadmetanja([FromBody] TipJavnogNadmetanjaCreationDTO tipJavnogNadmetanja)
        {
            try
            {
                var tip = mapper.Map<TipJavnogNadmetanja>(tipJavnogNadmetanja);
                TipJavnogNadmetanja confirmation = tipJavnogNadmetanjaRepository.CreateTipJavnogNadmetanja(tip);
                string location = linkGenerator.GetPathByAction("GetTipoviJavnogNadmetanja", "TipJavnogNadmetanja", new { TipJavnogNadmetanjaID = tip.TipJavnogNadmetanjaID });
                return Created(location, mapper.Map<TipJavnogNadmetanjaDTO>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja tipa javnog nadmetanja!");
            }
        }

        /// <summary>
        /// Ažurira jedan tip javnog nadmetanja
        /// </summary>
        /// <returns>Potvrda o modfikovanom tipu javnog nadmetanja</returns>
        /// <response code="200">Vraća kreirani tip javnog nadmetanja</response>
        /// <response code="400">Željeni tip javnog nadmetanja koji se želi ažurirati nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja tipa javnog nadmetanja</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipJavnogNadmetanjaDTO> UpdateTipJavnogNadmetanja([FromBody] TipJavnogNadmetanjaDTO tipJavnogNadmetanja)
        {

            try
            {
                TipJavnogNadmetanja stariTipJavnogNadmetanja = tipJavnogNadmetanjaRepository.GetTipJavnogNadmetanja(tipJavnogNadmetanja.TipJavnogNadmetanjaID);
                if (stariTipJavnogNadmetanja == null)
                {
                    return NotFound();
                }
                TipJavnogNadmetanja tip = mapper.Map<TipJavnogNadmetanja>(tipJavnogNadmetanja);
                mapper.Map(tip, stariTipJavnogNadmetanja);
                tipJavnogNadmetanjaRepository.SaveChanges();
                return Ok(mapper.Map<TipJavnogNadmetanja>(stariTipJavnogNadmetanja));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja tipa javnog nadmetanja!");
            }
        }
        /// <summary>
        /// Vrši brisanje jednog tipa javnog nadmetanja na osnovu ID-ja javnog nadmetanja.
        /// </summary>
        /// <param name="tipJavnogNadmetanjaID">ID tipa javnog nadmetanja</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Tip javnog nadmetanja uspešno obrisan</response>
        /// <response code="404">Nije pronađen tip javnog nadmetanja za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja tipa javnog nadmetanja</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{tipJavnogNadmetanjaID}")]
        public IActionResult DeleteTipJavnogNadmetanja(Guid tipJavnogNadmetanjaID)
        {
            try
            {
                var tipJavnogNadmetanja = tipJavnogNadmetanjaRepository.GetTipJavnogNadmetanja(tipJavnogNadmetanjaID);

                if (tipJavnogNadmetanja == null)
                {
                    return NotFound();
                }

                tipJavnogNadmetanjaRepository.DeleteTipJavnogNadmetanja(tipJavnogNadmetanjaID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja tipa javnog nadmetanja");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa tipom javnog nadmetanja
        /// </summary>
        [HttpOptions]
        public IActionResult GetTipJavnogNadmetanjaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}

