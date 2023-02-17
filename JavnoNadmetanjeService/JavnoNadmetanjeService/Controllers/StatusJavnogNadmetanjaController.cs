using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;
using JavnoNadmetanjeService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JavnoNadmetanjeService.Controllers
{
    [ApiController]
    [Route("api/statusJavnogNadmetanja")]
    public class StatusJavnogNadmetanjaController:ControllerBase
    {
        private readonly IStatusJavnogNadmetanjaRepository statusJavnogNadmetanjaRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public StatusJavnogNadmetanjaController(IStatusJavnogNadmetanjaRepository statusJavnogNadmetanjaRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.statusJavnogNadmetanjaRepository = statusJavnogNadmetanjaRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Vraca sve statuse javnih nadmetanja
        /// </summary>
        /// <returns> Lista statusa javnih nadmetanja </returns>
        /// <response code="200">Vraca listu statusa javnih nadmetanja</response>
        /// <response code="404">Ne postoji nijedan status javnih nadmetanja</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<StatusJavnogNadmetanjaDto>> GetStatusiJavnogNadmetanja()
        {
            List<StatusJavnogNadmetanja> statusiJavnogNadmetanja = statusJavnogNadmetanjaRepository.GetStatusiJavnogNadmetanja();
            if (statusiJavnogNadmetanja == null || statusiJavnogNadmetanja.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<StatusJavnogNadmetanjaDto>>(statusiJavnogNadmetanja));
        }

        /// <summary>
        /// Vraca jedan status javnih nadmetanja na osnovu ID-ja statusa javnog nadmetanja.
        /// </summary>
        /// <param name="statusJavnogNadmetanjaID">ID statusa javnog nadmetanja</param>
        /// <returns>Odgovarajući status javnog nadmetanja</returns>
        /// <response code="200">Vraća traženi status javnog nadmetanja</response>
        /// <response code="404">Nije pronadjen traženi status javnog nadmetanja</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{statusJavnogNadmetanjaID}")]
        public ActionResult<StatusJavnogNadmetanjaDto> GetStatusJavnogNadmetanjaByID(Guid statusJavnogNadmetanjaID)
        {
            var statusJavnogNadmetanja = statusJavnogNadmetanjaRepository.GetStatusJavnogNadmetanja(statusJavnogNadmetanjaID);
            if (statusJavnogNadmetanja == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StatusJavnogNadmetanjaDto>(statusJavnogNadmetanja));

        }
        /// <summary>
        /// Kreira novi status javnog nadmetanja.
        /// </summary>
        /// <param name="statusJavnogNadmetanja">Model statusa javnog nadmetanja</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog statusa javnog nadmetanja \
        /// POST /api/statusJavnogNadmetanja \
        /// { \
        /// "nazivStatusaJavnogNadmetanja": "Prvi krug" \
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreirani status javnog nadmetanja</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja statusa javnog nadmetanja</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusJavnogNadmetanjaDto> CreateStatusJavnogNadmetanja([FromBody] StatusJavnogNadmetanjaCreationDto statusJavnogNadmetanja)
        {
            try
            {
                var status = mapper.Map<StatusJavnogNadmetanja>(statusJavnogNadmetanja);
                StatusJavnogNadmetanja confirmation = statusJavnogNadmetanjaRepository.CreateStatusJavnogNadmetanja(status);
                string? location = linkGenerator.GetPathByAction("GetStatusiJavnogNadmetanja", "StatusJavnogNadmetanja", new { StatusJavnogNadmetanjaID = status.StatusJavnogNadmetanjaID });
                return Created(location, mapper.Map<StatusJavnogNadmetanjaDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja Statusa javnog nadmetanja!");
            }
        }

        /// <summary>
        /// Ažurira jedan status javnog nadmetanja
        /// </summary>
        /// <param name="statusJavnogNadmetanja">Model statusa javnog nadmetanja koji se ažurira</param>
        /// <returns>Potvrda o modfikovanom statusu javnog nadmetanja</returns>
        /// <response code="200">Vraća kreirani status javnog nadmetanja</response>
        /// <response code="400">Željeni status javnog nadmetanja koji se želi ažurirati nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja statusa javnog nadmetanja</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusJavnogNadmetanjaDto> UpdateStatusJavnogNadmetanja([FromBody] StatusJavnogNadmetanjaDto statusJavnogNadmetanja)
        {

            try
            {
                StatusJavnogNadmetanja stariStatusJavnogNadmetanja = statusJavnogNadmetanjaRepository.GetStatusJavnogNadmetanja(statusJavnogNadmetanja.StatusJavnogNadmetanjaID);
                if (stariStatusJavnogNadmetanja == null)
                {
                    return NotFound();
                }
                StatusJavnogNadmetanja status = mapper.Map<StatusJavnogNadmetanja>(statusJavnogNadmetanja);
                mapper.Map(status, stariStatusJavnogNadmetanja);
                statusJavnogNadmetanjaRepository.SaveChanges();
                return Ok(mapper.Map<StatusJavnogNadmetanja>(stariStatusJavnogNadmetanja));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja statusa javnog nadmetanja!");
            }
        }
        /// <summary>
        /// Vrši brisanje jednog statusa javnog nadmetanja na osnovu ID-ja javnog nadmetanja.
        /// </summary>
        /// <param name="statusJavnogNadmetanjaID">ID statusa javnog nadmetanja</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">status javnog nadmetanja uspešno obrisan</response>
        /// <response code="404">Nije pronađen status javnog nadmetanja za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja statusa javnog nadmetanja</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{statusJavnogNadmetanjaID}")]
        public IActionResult DeleteStatusJavnogNadmetanja(Guid statusJavnogNadmetanjaID)
        {
            try
            {
                var statusJavnogNadmetanja = statusJavnogNadmetanjaRepository.GetStatusJavnogNadmetanja(statusJavnogNadmetanjaID);

                if (statusJavnogNadmetanja == null)
                {
                    return NotFound();
                }

                statusJavnogNadmetanjaRepository.DeleteStatusJavnogNadmetanja(statusJavnogNadmetanjaID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja statusa javnog nadmetanja");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa statusom javnog nadmetanja
        /// </summary>
        [HttpOptions]
        public IActionResult GetStatusJavnogNadmetanjaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
