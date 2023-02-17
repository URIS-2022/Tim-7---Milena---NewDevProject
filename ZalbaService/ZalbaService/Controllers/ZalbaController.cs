using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZalbaService.Entities;
using ZalbaService.Models;
using ZalbaService.Models.Mock;
using ZalbaService.Repository;
using ZalbaService.ServiceCalls;

namespace ZalbaService.Controllers
{
    [ApiController]
    [Route("api/zalbe")]
    public class ZalbaController : ControllerBase
    {
        private readonly IZalbaRepository zalbaRepository;
        //private readonly IKupacMockRepository kupacMockRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly IKupacService kupacService;

        public ZalbaController(IZalbaRepository zalbaRepository, IMapper mapper, LinkGenerator linkGenerator, IKupacService kupacService)
        {
            this.zalbaRepository = zalbaRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.kupacService = kupacService;
        }

        /// <summary>
        /// Vraća sve žalbe.
        /// </summary>
        /// <param name="status">Status žalbe (npr. Usvojena)</param>
        /// <param name="tip">Tip žalbe (npr. Žalba na tok javnog nadmetanja)</param>
        /// <returns> Lista žalbi </returns>
        /// <response code="200">Vraca listu zalbi</response>
        /// <response code="404">Ne postoji nijedna zalba</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<ZalbaDTO>> GetZalbe([FromQuery] string? status = null, string? tip = null)
        {
            List<Zalba> z = zalbaRepository.GetZalbe(status, tip);
            var zalbe = mapper.Map<List<ZalbaDTO>>(z);
            if (zalbe == null || zalbe.Count == 0)
            {
                return NoContent();
            }
            foreach (var zalba in zalbe)
            {
                KupacInfoDto kupac = kupacService.GetKupacById(zalba.PodnosilacZalbeID).Result;
                zalba.Kupac = kupac;                          
            }
            return Ok(zalbe);
        }
        /// <summary>
        /// Vraca jednu žalbu na osnovu ID-ja žalbe.
        /// </summary>
        /// <param name="zalbaID">ID žalbe</param>
        /// <returns>Odgovarajuca žalba</returns>
        /// <response code="200">Vraća trazenu zalbu</response>
        /// <response code="404">Nije pronadjena tražena žalba</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{zalbaID}")]
        public ActionResult<ZalbaDTO> GetZalbaByID(Guid zalbaID)
        {
            Zalba z = zalbaRepository.GetZalba(zalbaID);
            var zalba = mapper.Map<ZalbaDTO>(z);
            if (zalba == null)
            {
                return NoContent();
            }

            KupacInfoDto kupac = kupacService.GetKupacById(zalba.PodnosilacZalbeID).Result;
            zalba.Kupac = kupac;
            
            return Ok(zalba);

        }
        /// <summary>
        /// Kreira novu žalbu.
        /// </summary>
        /// <param name="zalba">Model zalbe</param>
        /// <returns>Potvrdu o kreiranoj zalbi.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove žalbe \
        /// POST /api/zalba \
        /// { \
        ///"datumPodnosenjaZalbe": "2023-02-16T15:18:57.945Z", \
        ///"razlogZalbe": "string", \
        ///"obrazlozenje": "string", \
        ///"brojNadmetanja": "string", \
        ///"datumResenja": "2023-02-16T15:18:57.945Z", \
        ///"brojResenja": "string", \
        ///"tipZalbeID": "d5d6624e-48f6-4167-bb07-9e8589fd9281", \
        ///"statusZalbeID": "50d01344-9793-4b98-8f95-2196f8eb09da", \
        ///"radnjaNaOsnovuZalbeID": "af98278e-4a44-462f-9978-460b1ab8e2d1", \
        ///"podnosilacZalbeID": "3fa85f64-5717-4562-b3fc-2c963f66afa6" \
        ///}
        /// </remarks>
        /// <response code="201">Vraća kreiranu žalbu</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja žalbe</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZalbaConfirmationDTO> CreateZalba([FromBody] ZalbaCreationDTO zalba)
        {
            try
            {
                var z = mapper.Map<Zalba>(zalba);
                Zalba confirmation = zalbaRepository.CreateZalba(z);
                string? location = linkGenerator.GetPathByAction("GetZalbe", "Zalba", new { ZalbaID = z.ZalbaID });
                return Created(location, mapper.Map<ZalbaConfirmationDTO>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja žalbe!");
            }
        }

        /// <summary>
        /// Ažurira jednu žalbu
        /// </summary>
        /// <param name="zalba">Model žalbe koja se ažurira</param>
        /// <returns>Potvrda o modfikovanoj žalbi</returns>
        /// <response code="200">Vraća kreiranu žalbu</response>
        /// <response code="400">Žalba koja se želi ažurirati nije pronađena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja žalbe</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  ActionResult<ZalbaUpdateDTO> UpdateZalba([FromBody] ZalbaUpdateDTO zalba)
        {

            try
            {
                Zalba staraZalba = zalbaRepository.GetZalba(zalba.ZalbaID);
                if (staraZalba == null)
                {              
                    return NotFound();
                }
                Zalba novaZalba = mapper.Map<Zalba>(zalba);
                zalbaRepository.UpdateZalba(staraZalba, novaZalba);
                return Ok(mapper.Map<ZalbaUpdateDTO>(novaZalba));

            }
            catch (Exception)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja žalbe!");
            }
        }

        /// <summary>
        /// Vrši brisanje jedne žalbe na osnovu ID-ja žalbe.
        /// </summary>
        /// <param name="zalbaID">ID žalbe</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Žalba uspešno obrisana</response>
        /// <response code="404">Nije pronađena žalba za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja žalbe</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{zalbaID}")]
        public IActionResult DeleteZalba(Guid zalbaID)
        {
            try
            {
                var zalba = zalbaRepository.GetZalba(zalbaID);

                if (zalba == null)
                {
                    return NotFound();
                }

                zalbaRepository.DeleteZalba(zalbaID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja žalbe");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa žalbom
        /// </summary>
        [HttpOptions]
        public IActionResult GetZalbaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
