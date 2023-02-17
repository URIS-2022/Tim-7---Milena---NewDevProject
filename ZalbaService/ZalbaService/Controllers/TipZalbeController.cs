using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZalbaService.Entities;
using ZalbaService.Models;
using ZalbaService.Repository;

namespace ZalbaService.Controllers
{
    [ApiController]
    [Route("api/tipZalbe")]
    public class TipZalbeController : ControllerBase
    {
        private readonly ITipZalbeRepository tipZalbeRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public TipZalbeController(ITipZalbeRepository tipZalbeRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.tipZalbeRepository = tipZalbeRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Vraca sve tipove žalbi
        /// </summary>
        /// <returns> Lista tipova žalbi </returns>
        /// <response code="200">Vraca listu tipova žalbi</response>
        /// <response code="404">Ne postoji nijedan tip žalbe</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<TipZalbeDTO>> GetTipoviZalbi()
        {
            List<TipZalbe> tipoviZalbi = tipZalbeRepository.GetTipoviZalbi();
            if (tipoviZalbi == null || tipoviZalbi.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<TipZalbeDTO>>(tipoviZalbi));
        }

        /// <summary>
        /// Vraca jedan tip žalbe na osnovu ID-ja tipa žalbe.
        /// </summary>
        /// <param name="tipZalbeID">ID tipa žalbe</param>
        /// <returns>Odgovarajući tip žalbe</returns>
        /// <response code="200">Vraća traženi tip žalbe</response>
        /// <response code="404">Nije pronadjen traženi tip žalbe</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{tipZalbeID}")]
        public ActionResult<TipZalbeDTO> GetTipZalbeByID(Guid tipZalbeID)
        {
            var tipZalbe = tipZalbeRepository.GetTipZalbe(tipZalbeID);
            if (tipZalbe == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<TipZalbeDTO>(tipZalbe));

        }
        /// <summary>
        /// Kreira novi tip žalbe.
        /// </summary>
        /// <param name="tipZalbe">Model tipa žalbe</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog tipa žalbe \
        /// POST /api/tipZalbe \
        /// { \
        /// "nazivTipaZalbe": "Žalba na tok javnog nadmetanja" \
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreirani tip žalbe</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja tipa žalbe</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipZalbeDTO> CreateTipZalbe([FromBody] TipZalbeCreationDTO tipZalbe)
        {
            try
            {
                var tip = mapper.Map<TipZalbe>(tipZalbe);
                TipZalbe confirmation = tipZalbeRepository.CreateTipZalbe(tip);
                string? location = linkGenerator.GetPathByAction("GetTipoviZalbi", "TipZalbe", new { TipZalbeID = tip.TipZalbeID });
                return Created(location, mapper.Map<TipZalbeDTO>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja tipa žalbe!");
            }
        }

        /// <summary>
        /// Ažurira jedan tip žalbe
        /// </summary>
        /// <param name="tipZalbe">Model tipa žalbe koja se ažurira</param>
        /// <returns>Potvrda o modfikovanom tipu žalbe</returns>
        /// <response code="200">Vraća kreiranu žalbu</response>
        /// <response code="400">Tip žalbe koja se želi ažurirati nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja tipa žalbe</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipZalbeDTO> UpdateTipZalbe([FromBody] TipZalbeDTO tipZalbe)
        {

            try
            {
                TipZalbe stariTipZalbe = tipZalbeRepository.GetTipZalbe(tipZalbe.TipZalbeID);
                if (stariTipZalbe == null)
                {
                    return NotFound();
                }
                TipZalbe tip = mapper.Map<TipZalbe>(tipZalbe);
                mapper.Map(tip, stariTipZalbe);
                tipZalbeRepository.SaveChanges();
                return Ok(mapper.Map<TipZalbe>(stariTipZalbe));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja tipa žalbe!");
            }
        }
        /// <summary>
        /// Vrši brisanje jednog tipa žalbe na osnovu ID-ja žalbe.
        /// </summary>
        /// <param name="tipZalbeID">ID tipa žalbe</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Tip žalbe uspešno obrisan</response>
        /// <response code="404">Nije pronađen tip žalba za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja tipa žalbe</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{tipZalbeID}")]
        public IActionResult DeleteTipZalbe(Guid tipZalbeID)
        {
            try
            {
                var tipZalbe = tipZalbeRepository.GetTipZalbe(tipZalbeID);

                if (tipZalbe == null)
                {
                    return NotFound();
                }

                tipZalbeRepository.DeleteTipZalbe(tipZalbeID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja tipa žalbe");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa tipom žalbe
        /// </summary>
        [HttpOptions]
        public IActionResult GetTipZalbeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}
