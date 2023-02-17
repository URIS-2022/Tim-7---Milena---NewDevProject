using AutoMapper;
using KupacServis.Data;
using KupacServis.Entities;
using KupacServis.Models;
using Microsoft.AspNetCore.Mvc;

namespace KupacServis.Controllers
{
    [Route("api/prioritet")]
    [ApiController]
    public class PrioritetController:ControllerBase
    {

        private readonly IPrioritetRepository _prioritetRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
       

        public PrioritetController(IPrioritetRepository prioritetRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _prioritetRepository = prioritetRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
          
        }

        /// <summary>
        /// Vraća sve moguće prioritete kupaca.
        /// </summary>
        /// <response code="200">Vraća listu prioriteta</response>
        /// /// <response code="204">Nema kontenta</response>
        /// <response code="404">Nije pronađeno nijedan prioritet</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<PrioritetDto>> GetPrioritets()
        {
            var prioriteti = _mapper.Map<List<PrioritetDto>>(_prioritetRepository.GetPrioritets());
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(prioriteti);

        }
        /// <summary>
        /// Vraća jednan prioritet na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="id">ID prioriteta </param>
        /// <returns></returns>
        /// <response code="200">Vraća traženi prioritet</response>
        /// <response code="404">Vraća da prioritet nije pronađen</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<PrioritetDto> GetPrioritetById(Guid id)
        {
            var prioritet = _mapper.Map<PrioritetDto>(_prioritetRepository.GetPrioritetById(id));
          

            if (prioritet == null)
            {
                return NotFound();
            }
            return Ok(prioritet);
        }

        /// <summary>
        /// Vrši brisanje jednog prioriteta na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="id">ID prioriteta</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Prioritet  uspješno obrisan</response>
        /// <response code="404">Nije pronađen prioritet za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja prioriteta</response>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult DeletePrioritet(Guid id)
        {

            try
            {
                var prioritet = _prioritetRepository.GetPrioritetById(id);

                if (prioritet == null)
                {
                    return NotFound();
                }

                _prioritetRepository.DeletePrioritet(id);
                _prioritetRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        /// <summary>
        /// Ažurira jedan prioritet.
        /// </summary>
        /// <param name="prioritet">Model prioriteta koji se ažurira.</param>
        /// <returns>Potvrdu o modifikovanom prioritetu.</returns>
        /// <response code="200">Vraća ažurirani prioritet.</response>
        /// <response code="404">Prioritet koje se ažurira nije pronađeno.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja prioriteta.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PrioritetDto> UpdatePrioritet(PrioritetUpdateDto prioritet)
        {
            try
            {
                
                var oldPrioritet = _prioritetRepository.GetPrioritetById(prioritet.PrioritetId);
                if (oldPrioritet == null)
                {
                    return NotFound(); //Ukoliko ne postoji vratiti status 404 (NotFound).
                }
                Prioritet prioritetEntity = _mapper.Map<Prioritet>(prioritet);

                _mapper.Map(prioritetEntity, oldPrioritet); //Update objekta koji treba da sačuvamo u bazi                

                _prioritetRepository.SaveChanges(); //Perzistiramo promjene
                return Ok(_mapper.Map<PrioritetDto>(oldPrioritet));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
        /// <summary>
        /// Kreiranje novog prioriteta.
        /// </summary>
        /// <param name="prioritet">Model prioriteta</param>
        /// <returns>Potvrdu o kreiranom prioritetu.</returns>
        /// <remarks>
        /// Primjer zahtjeva za kreiranje novog prioriteta \
        /// POST /api/prioritet \
        /// {     \
        ///     "OpisPrioriteta":"Pravi prioritet", \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreirani prioritet</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja prioriteta</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<PrioritetDto> CreatePrioritet([FromBody] PrioritetCreationDto prioritet)
        {
            try
            {
                Prioritet prioritetEntity = _mapper.Map<Prioritet>(prioritet);
                Prioritet pri = _prioritetRepository.CreatePrioritet(prioritetEntity);
                _prioritetRepository.SaveChanges(); //Perzistiramo promjene



                string? location = _linkGenerator.GetPathByAction("GetPrioritets", "Prioritet", new { PrioritetId = pri.PrioritetId });
                return Created(location, _mapper.Map<PrioritetDto>(pri));


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa prioritetom
        /// </summary>
        [HttpOptions]
        public IActionResult GetPrioritetOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }


    }
}
