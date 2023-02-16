using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UgovorService.Entities;
using UgovorService.Models;
using UgovorService.Repositories;

namespace UgovorService.Controllers
{
    [ApiController]
    [Route("api/dokument")]
    public class DokumentController:ControllerBase
    {
        private readonly IDokumentRepository dokumentRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public DokumentController(IDokumentRepository dokumentRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.dokumentRepository = dokumentRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }
        /// <summary>
        /// Vraca sva dokumenta
        /// </summary>
        /// <returns> Lista dokumenata </returns>
        /// <response code="200">Vraca listu dokumenata</response>
        /// <response code="404">Ne postoji nijedan dokument</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<DokumentDTO>> GetDokumente()
        {
            List<Dokument> dokumenti = dokumentRepository.GetDokumente();
            if (dokumenti == null || dokumenti.Count == 0)
            {
                return NoContent();
            }
            return Ok(mapper.Map<List<DokumentDTO>>(dokumenti));
        }

        /// <summary>
        /// Vraca jedan dokument na osnovu ID-ja dokumenta.
        /// </summary>
        /// <param name="dokumentID">ID dokumenta</param>
        /// <returns>Odgovarajuc dokument</returns>
        /// <response code="200">Vraća trazen dokument</response>
        /// <response code="404">Nije pronadjen dokument</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{dokumentID}")]
        public ActionResult<DokumentDTO> GetDokumentByID(Guid dokumentID)
        {
            var dokument = dokumentRepository.GetDokument(dokumentID);
            if (dokument == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<DokumentDTO>(dokument));

        }

        /// <summary>
        /// Kreira novi dokument.
        /// </summary>
        
        /// <response code="201">Vraća kreirani dokument</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja dokumenta</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DokumentConfirmationDTO> CreateDokument([FromBody] DokumentCreationDTO dokument)
        {
            try
            {
                var z = mapper.Map<Dokument>(dokument);
                Dokument confirmation = dokumentRepository.CreateDokument(z);
                string location = linkGenerator.GetPathByAction("GetDokumente", "Dokument", new { DokumentID = z.DokumentID });
                return Created(location, mapper.Map<DokumentConfirmationDTO>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja dokumenta!");
            }
        }

        /// <summary>
        /// Vrši brisanje jednog dokumenta na osnovu ID-ja dokumenta.
        /// </summary>
        /// <param name="dokumentID">ID dokumenta</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Dokument uspešno obrisan</response>
        /// <response code="404">Nije pronađen dokument za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja dokumenta</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{dokumentID}")]
        public IActionResult DeleteDokument(Guid dokumentID)
        {
            try
            {
                var dokument = dokumentRepository.GetDokument(dokumentID);

                if (dokument == null)
                {
                    return NotFound();
                }

                dokumentRepository.DeleteDokument(dokumentID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja dokumenta");
            }
        }

        /// <summary>
        /// Ažurira jedan dokument
        /// </summary>
        /// <returns>Potvrda o modifikovanom dokumentu</returns>
        /// <response code="200">Vraća kreiran dokument</response>
        /// <response code="400">Željen dokument koja se želi ažurirati nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja dokumenta</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DokumentUpdateDTO> UpdateDokument([FromBody] DokumentUpdateDTO dokument)
        {

            try
            {
                Dokument stariDokument = dokumentRepository.GetDokument(dokument.DokumentID);
                if (stariDokument == null)
                {
                    return NotFound();
                }
                Dokument noviDokument = mapper.Map<Dokument>(dokument);
                dokumentRepository.UpdateDokument(stariDokument, noviDokument);
                return Ok(mapper.Map<DokumentUpdateDTO>(noviDokument));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja dokumenta!");
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa dokumentom
        /// </summary>
        [HttpOptions]
        public IActionResult GetDokumentOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }






    }
}
