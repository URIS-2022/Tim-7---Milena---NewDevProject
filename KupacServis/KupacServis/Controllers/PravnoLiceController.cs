using AutoMapper;
using KupacServis.Data;
using KupacServis.Entities;
using KupacServis.Models;
using Microsoft.AspNetCore.Mvc;

namespace KupacServis.Controllers
{
    [Route("api/pravnoLice")]
    [ApiController]
    public class PravnoLiceController : ControllerBase
    {

        private readonly IPravnoLiceRepository _pravnoLiceRepository;
        private readonly IKupacRepository _kupacRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;


        public PravnoLiceController(IPravnoLiceRepository pravnoLiceRepository, IMapper mapper, LinkGenerator linkGenerator,IKupacRepository kupacRepository)
        {
            _pravnoLiceRepository = pravnoLiceRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _kupacRepository = kupacRepository;
        }

        /// <summary>
        /// Vraća sva pravna lica.
        /// </summary>
        /// <response code="200">Vraća listu pravnih lica</response>
        /// /// <response code="204">Nema kontenta</response>
        /// <response code="404">Nije pronađeno pravno lice</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<PravnoLiceDto>> GetPravnoLices()
        {
            var pravnaLica = _mapper.Map<List<PravnoLiceDto>>(_pravnoLiceRepository.GetPravnoLices());

            if(pravnaLica == null)
            {
                return NoContent();
            }

            return Ok(pravnaLica);

        }

        /// <summary>
        /// Vraća jedno pravno lice na osnovu ID-ja.
        /// </summary>
        /// <param name="id">ID pranog lica</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženo pravno lice</response>
        /// <response code="404">Vraća da lice nije pronađeno</response>

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<PravnoLice> GetPravnoLiceById(Guid id)
        {
            var pravnoLice = _mapper.Map<PravnoLiceDto>(_pravnoLiceRepository.GetPravnoLiceById(id));


            if (pravnoLice == null)
            {
                return NotFound();
            }
            return Ok(pravnoLice);
        }

        /// <summary>
        /// Vrši brisanje jednog pravnog lica na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="id">ID pravnog lica</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Pravno lice  uspješno obrisano</response>
        /// <response code="404">Nije pronađeno pravno lice za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja pravnog lica</response>


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult DeletePravnoLice(Guid id)
        {

            try
            {
                var pravnoLice = _pravnoLiceRepository.GetPravnoLiceById(id);

                if (pravnoLice == null)
                {
                    return NotFound();
                }

                _pravnoLiceRepository.DeletePravnoLice(id);
                _pravnoLiceRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        /// <summary>
        /// Ažurira jedno pravno lice.
        /// </summary>
        /// <param name="pravnoLice">Model pravnog lica koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom pravnom licu.</returns>
        /// <response code="200">Vraća ažurirano pravno lice</response>
        /// <response code="400">Pravno lice koje se ažurira nije pronađeno</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja pravnog lica</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PravnoLiceDto> UpdatePravnoLice(PravnoLiceUpdateDto pravnoLice)
        {
            try
            {
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                var oldPravnoLice = _pravnoLiceRepository.GetPravnoLiceById(pravnoLice.PravnoLiceId);
                if (oldPravnoLice == null)
                {
                    return NotFound(); //Ukoliko ne postoji vratiti status 404 (NotFound).
                }
                PravnoLice pravnoLiceEntity = _mapper.Map<PravnoLice>(pravnoLice);

                _mapper.Map(pravnoLiceEntity, oldPravnoLice); //Update objekta koji treba da sačuvamo u bazi                

                _pravnoLiceRepository.SaveChanges(); //Perzistiramo promene
                return Ok(_mapper.Map<PravnoLiceDto>(oldPravnoLice));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
        /// <summary>
        /// Kreira novo pravno lice.
        /// </summary>
        /// <param name="pravnoLice">Model pravnog lica</param>
        /// <returns>Potvrdu o kreiranom pravnom licu.</returns>
        /// <remarks>
        /// Primjer zahtjeva za kreiranje novog pravnog lica \
        /// POST /api/pravnoLice \
        /// {     \
        ///     "Naziv":"PravnoLice123", \
        ///     "MaticniBroj": "12345678", \
        ///     "Faks": "fa09890", \
        ///     "KupacId":"BEF0EDDB-E1E5-4E5E-A7F1-2BC1D32BB9D3", \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreirano pravno lice</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja pravnog lica</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PravnoLice> CreatePravnoLice([FromBody] PravnoLiceCreationDto pravnoLice)
        {
            try
            {
                PravnoLice pravnoLiceEntity = _mapper.Map<PravnoLice>(pravnoLice);
                

                PravnoLice pl = _pravnoLiceRepository.CreatePravnoLice(pravnoLiceEntity);
                _pravnoLiceRepository.SaveChanges(); //Perzistiramo promene



                string location = _linkGenerator.GetPathByAction("GetPravnoLices", "PravnoLice", new { PravnoLiceId = pl.PravnoLiceId });
                return Created(location, _mapper.Map<PravnoLiceDto>(pl));


            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa pravnim licem
        /// </summary>
        [HttpOptions]
        public IActionResult GetPravnoLiceOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
    }
