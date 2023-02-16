using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZalbaService.Entities;
using ZalbaService.Models;
using ZalbaService.Repository;

namespace ZalbaService.Controllers
{
    [ApiController]
    [Route("api/statusZalbe")]
    public class StatusZalbeController:ControllerBase
    {
        private readonly IStatusZalbeRepository statusZalbeRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public StatusZalbeController(IStatusZalbeRepository statusZalbeRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.statusZalbeRepository = statusZalbeRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        /// <summary>
        /// Vraca sve statuse žalbi
        /// </summary>
        /// <returns> Lista statusa žalbi </returns>
        /// <response code="200">Vraca listu statusa žalbi</response>
        /// <response code="404">Ne postoji nijedan status žalbe</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<StatusZalbeDTO>> GetStatusiZalbi()
        {
            List<StatusZalbe> statusiZalbi = statusZalbeRepository.GetStatusiZalbi();
            if (statusiZalbi == null || statusiZalbi.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<StatusZalbeDTO>>(statusiZalbi));
        }

        /// <summary>
        /// Vraca jedan status žalbe na osnovu ID-ja statusa žalbe.
        /// </summary>
        /// <param name="statusZalbeID">ID statusa žalbe</param>
        /// <returns>Odgovarajući status žalbe</returns>
        /// <response code="200">Vraća traženi status žalbe</response>
        /// <response code="404">Nije pronadjen traženi status žalbe</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{statusZalbeID}")]
        public ActionResult<StatusZalbeDTO> GetStatusZalbeByID(Guid statusZalbeID)
        {
            var statusZalbe = statusZalbeRepository.GetStatusZalbe(statusZalbeID);
            if (statusZalbe == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<StatusZalbeDTO>(statusZalbe));

        }
        /// <summary>
        /// Kreira novi status žalbe.
        /// </summary>
        /// <param name="statusZalbe">Model statusa žalbe</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog statusa žalbe \
        /// POST /api/statusZalbe \
        /// { \
        /// "nazivStatusaZalbe": "Usvojena" \
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreirani status žalbe</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja statusa žalbe</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusZalbeDTO> CreateStatusZalbe([FromBody] StatusZalbeCreationDTO statusZalbe)
        {
            try
            {
                var status = mapper.Map<StatusZalbe>(statusZalbe);
                StatusZalbe confirmation = statusZalbeRepository.CreateStatusZalbe(status);
                string location = linkGenerator.GetPathByAction("GetStatusiZalbi", "StatusZalbe", new { StatusZalbeID = status.StatusZalbeID });
                return Created(location, mapper.Map<StatusZalbeDTO>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja statusa žalbe!");
            }
        }

        /// <summary>
        /// Ažurira jedan status žalbe
        /// </summary>
        /// <param name="statusZalbe">Model statusa žalbe koja se ažurira</param>
        /// <returns>Potvrda o modfikovanom statusu žalbe</returns>
        /// <response code="200">Vraća kreirani status žalbe</response>
        /// <response code="400">Status žalbe koja se želi ažurirati nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja statusa žalbe</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StatusZalbeDTO> UpdateStatusZalbe([FromBody] StatusZalbeDTO statusZalbe)
        {

            try
            {
                StatusZalbe stariStatusZalbe = statusZalbeRepository.GetStatusZalbe(statusZalbe.StatusZalbeID);
                if (stariStatusZalbe == null)
                {
                    return NotFound();
                }
                StatusZalbe status = mapper.Map<StatusZalbe>(statusZalbe);
                mapper.Map(status, stariStatusZalbe);
                statusZalbeRepository.SaveChanges();
                return Ok(mapper.Map<StatusZalbe>(stariStatusZalbe));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja statusa žalbe!");
            }
        }
        /// <summary>
        /// Vrši brisanje jednog statusa žalbe na osnovu ID-ja žalbe.
        /// </summary>
        /// <param name="statusZalbeID">ID statusa žalbe</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Status žalbe uspešno obrisan</response>
        /// <response code="404">Nije pronađen status žalba za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja statusa žalbe</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{statusZalbeID}")]
        public IActionResult DeleteStatusZalbe(Guid statusZalbeID)
        {
            try
            {
                var statusZalbe = statusZalbeRepository.GetStatusZalbe(statusZalbeID);

                if (statusZalbe == null)
                {
                    return NotFound();
                }

                statusZalbeRepository.DeleteStatusZalbe(statusZalbeID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja statusa žalbe");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa statusom žalbe
        /// </summary>
        [HttpOptions]
        public IActionResult GetStatusZalbeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }


    }
}
