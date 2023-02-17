using AutoMapper;
using KupacServis.Data;
using KupacServis.Entities;
using KupacServis.Models;
using Microsoft.AspNetCore.Mvc;

namespace KupacServis.Controllers
{
    [Route("api/fizickoLice")]
    [ApiController]
    public class FizickoLiceController : ControllerBase
    {

        private readonly IFizickoLiceRepository _fizickoLiceRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;


        public FizickoLiceController(IFizickoLiceRepository fizickoLiceRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _fizickoLiceRepository = fizickoLiceRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;

        }

        /// <summary>
        /// Vraća sva fizička lica.
        /// </summary>
        /// <response code="200">Vraća listu fizičkih lica</response>
        /// /// <response code="204">Nema kontenta</response>
        /// <response code="404">Nije pronađeno nijedno fizičko lice</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<FizickoLiceDto>> GetFizickoLices()
        {
            var fizickoLice = _mapper.Map<List<FizickoLiceDto>>(_fizickoLiceRepository.GetFizickoLices());
            if(fizickoLice == null)
            {
                return NoContent();
            }

          
            return Ok(fizickoLice);

        }
        /// <summary>
        /// Vraća jedno fizičko lice na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="id">ID fizičkog lica</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženo fizičko lice</response>
        /// <response code="404">Vraća da lice nije pronađeno</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<FizickoLice> GetFizickoLiceById(Guid id)
        {
            var fizickaLica = _mapper.Map<FizickoLiceDto>(_fizickoLiceRepository.GetFizickoLiceById(id));


            if (fizickaLica == null)
            {
                return NotFound();
            }
            return Ok(fizickaLica);
        }

        /// <summary>
        /// Vrši brisanje jednog fizičkog lica na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="id">ID fizičkog lica</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Fizičko lice  uspješno obrisano</response>
        /// <response code="404">Nije pronađeno fizičko lice za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja fizičkog lica</response>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult DeleteFizickoLice(Guid id)
        {

            try
            {
                var fizickoLice = _fizickoLiceRepository.GetFizickoLiceById(id);

                if (fizickoLice == null)
                {
                    return NotFound();
                }

                _fizickoLiceRepository.DeleteFizickoLice(id);
                _fizickoLiceRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }


        /// <summary>
        /// Ažurira jedno fizičko lice.
        /// </summary>
        /// <param name="fizickoLice">Model fizičkog lica koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom fizičkom licu.</returns>
        /// <response code="200">Vraća ažurirano fizičko lice</response>
        /// <response code="400">Fizičko lice koje se ažurira nije pronađeno</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja fizičkog lica</response>

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FizickoLiceDto> UpdateFizickoLice(FizickoLiceUpdateDto fizickoLice)
        {
            try
            {
                //Proveriti da li uopšte postoji prijava koju pokušavamo da ažuriramo.
                var oldFizickoLice = _fizickoLiceRepository.GetFizickoLiceById(fizickoLice.FizickoLiceId);
                if (oldFizickoLice == null)
                {
                    return NotFound(); //Ukoliko ne postoji vratiti status 404 (NotFound).
                }
                FizickoLice fizickoLiceEntity = _mapper.Map<FizickoLice>(fizickoLice);

                _mapper.Map(fizickoLiceEntity, oldFizickoLice); //Update objekta koji treba da sačuvamo u bazi                

                _fizickoLiceRepository.SaveChanges(); //Perzistiramo promene
                return Ok(_mapper.Map<FizickoLiceDto>(oldFizickoLice));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }


        /// <summary>
        /// Kreira novo fizičko lice.
        /// </summary>
        /// <param name="fizickoLice">Model fizičkog lica</param>
        /// <returns>Potvrdu o kreiranom fizičkom licu.</returns>
        /// <remarks>
        /// Primjer zahtjeva za kreiranje novog fizičkog lica \
        /// POST /api/fizickoLice \
        /// {     \
        ///     "Ime":"Marko", \
        ///     "Prezime": "Markovic", \
        ///     "JMBG": "0806999876565", \
        ///     "KupacId":"4563cf92-b8d0-4574-9b40-a725f884da36", \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreirano fizičko lice</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja fizičkog lica</response>

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<FizickoLice> CreateFizckoLice([FromBody] FizickoLiceCreationDto fizickoLice)
        {
            try
            {
                FizickoLice fizickoLiceEntity = _mapper.Map<FizickoLice>(fizickoLice);


                FizickoLice fl = _fizickoLiceRepository.CreateFizickoLice(fizickoLiceEntity);
                _fizickoLiceRepository.SaveChanges(); //Perzistiramo promene



                string location = _linkGenerator.GetPathByAction("GetFizickoLices", "FizickoLice", new { FizickoLiceId = fl.FizickoLiceId });
                return Created(location, _mapper.Map<FizickoLiceDto>(fl));


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa fizičkim licem
        /// </summary>
        [HttpOptions]
        public IActionResult GetFizickoLiceOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
    }
