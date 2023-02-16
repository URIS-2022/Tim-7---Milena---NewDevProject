using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using ZalbaService.Entities;
using ZalbaService.Models;
using ZalbaService.Repository;

namespace ZalbaService.Controllers
{
    [ApiController]
    [Route("api/radnjaNaOsnovuZalbe")]
    public class RadnjaNaOsnovuZalbeController:ControllerBase
    {
        private readonly IRadnjaNaOsnovuZalbeRepository radnjaNaOsnovuZalbeRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public RadnjaNaOsnovuZalbeController(IRadnjaNaOsnovuZalbeRepository radnjaNaOsnovuZalbeRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.radnjaNaOsnovuZalbeRepository = radnjaNaOsnovuZalbeRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }


        /// <summary>
        /// Vraca sve radnje na osnovu žalbe
        /// </summary>
        /// <returns> Lista radnji na osnovu žalbe </returns>
        /// <response code="200">Vraca listu radnji na osnovu žalbe</response>
        /// <response code="404">Ne postoji nijedna radnja na osnovu žalbe</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<RadnjaNaOsnovuZalbeDTO>> GetRadnjeNaOsnovuZalbe()
        {
            List<RadnjaNaOsnovuZalbe> radnjeNaOsnovuZalbe = radnjaNaOsnovuZalbeRepository.GetRadnjeNaOsnovuZalbi();
            if (radnjeNaOsnovuZalbe == null || radnjeNaOsnovuZalbe.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<RadnjaNaOsnovuZalbeDTO>>(radnjeNaOsnovuZalbe));
        }

        /// <summary>
        /// Vraca jednu radnju na osnovu žalbe na osnovu ID-ja radnje na osnovu žalbe.
        /// </summary>
        /// <param name="radnjaNaOsnovuZalbeID">ID radnje na osnovu žalbe</param>
        /// <returns>Odgovarajući radnja na osnovu žalbe</returns>
        /// <response code="200">Vraća traženu radnju na osnovu žalbe</response>
        /// <response code="404">Nije pronadjena tražena radnja na osnovu žalbe</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{radnjaNaOsnovuZalbeID}")]
        public ActionResult<RadnjaNaOsnovuZalbeDTO> GetRadnjaNaOsnovuZalbeByID(Guid radnjaNaOsnovuZalbeID)
        {
            var radnjaNaOsnovuZalbe = radnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbe(radnjaNaOsnovuZalbeID);
            if (radnjaNaOsnovuZalbe == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<RadnjaNaOsnovuZalbeDTO>(radnjaNaOsnovuZalbe));

        }
        /// <summary>
        /// Kreira novu radnju na osnovu žalbe
        /// </summary>
        /// <param name="radnjaNaOsnovuZalbe">Model radnje na osnovu žalbe</param>
        /// <remarks>
        /// Primer zahteva za kreiranje nove radnje na osnovu žalbe \
        /// POST /api/radnjaNaOsnovuZalbe \
        /// { \
        /// "nazivRadnjeNaOsnovuZalbe": "JN ide u drugi krug sa novim uslovima" \
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreiranu radnju na osnovu žalbe</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja radnje na osnovu žalbe</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RadnjaNaOsnovuZalbeDTO> CreateRadnjaNaOsnovuZalbe([FromBody] RadnjaNaOsnovuZalbeCreationDTO radnjaNaOsnovuZalbe)
        {
            try
            {
                var radnja = mapper.Map<RadnjaNaOsnovuZalbe>(radnjaNaOsnovuZalbe);
                RadnjaNaOsnovuZalbe confirmation = radnjaNaOsnovuZalbeRepository.CreateRadnjaNaOsnovuZalbe(radnja);
                string location = linkGenerator.GetPathByAction("GetRadnjeNaOsnovuZalbe", "RadnjaNaOsnovuZalbe", new { RadnjaNaOsnovuZalbeID = radnja.RadnjaNaOsnovuZalbeID });
                return Created(location, mapper.Map<RadnjaNaOsnovuZalbeDTO>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja radnje na osnovu žalbe!");
            }
        }

        /// <summary>
        /// Ažurira jednu radnju na osnovu žalbe
        /// </summary>
        /// <param name="radnjaNaOsnovuZalbe">Model radnje na osnovu žalbe koja se ažurira</param>
        /// <returns>Potvrda o modfikovanoj radnji na osnovu žalbe</returns>
        /// <response code="200">Vraća kreiranu radnju na osnovu žalbu</response>
        /// <response code="400">Željena radnja na osnovu žalbe koja se želi ažurirati nije pronađena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja radnje na osnovu žalbe</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RadnjaNaOsnovuZalbeDTO> UpdateRadnjaNaOsnovuZalbe([FromBody] RadnjaNaOsnovuZalbeDTO radnjaNaOsnovuZalbe)
        {

            try
            {
                RadnjaNaOsnovuZalbe staraRadnja = radnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbe(radnjaNaOsnovuZalbe.RadnjaNaOsnovuZalbeID);
                if (staraRadnja == null)
                {
                    return NotFound();
                }
                RadnjaNaOsnovuZalbe radnja = mapper.Map<RadnjaNaOsnovuZalbe>(radnjaNaOsnovuZalbe);
                mapper.Map(radnja, staraRadnja);
                radnjaNaOsnovuZalbeRepository.SaveChanges();
                return Ok(mapper.Map<RadnjaNaOsnovuZalbe>(staraRadnja));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja statusa žalbe!");
            }
        }
        /// <summary>
        /// Vrši brisanje jedne radnje na osnovu žalbe na osnovu ID-ja radnje na osnovu žalbe.
        /// </summary>
        /// <param name="radnjaNaOsnovuZalbeID">ID radnje na osnovu žalbe</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Radnaj na osnovu žalbe uspešno obrisana</response>
        /// <response code="404">Nije pronađena radnja na osnovu žalbe za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja radnje na osnovu žalbe</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{radnjaNaOsnovuZalbeID}")]
        public IActionResult DeleteRadnjaNaOsnovuZalbe(Guid radnjaNaOsnovuZalbeID)
        {
            try
            {
                var radnjaNaOsnovuZalbe = radnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbe(radnjaNaOsnovuZalbeID);

                if (radnjaNaOsnovuZalbe == null)
                {
                    return NotFound();
                }

                radnjaNaOsnovuZalbeRepository.DeleteRadnjaNaOsnovuZalbe(radnjaNaOsnovuZalbeID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja radnje na osnovu žalbe");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa radnjom na osnovu žalbe
        /// </summary>
        [HttpOptions]
        public IActionResult GetRadnjaNaOsnovuZalbeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}
