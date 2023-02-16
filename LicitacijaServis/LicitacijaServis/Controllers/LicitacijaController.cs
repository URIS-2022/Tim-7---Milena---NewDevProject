using AutoMapper;
using LicitacijaServis.Data;
using LicitacijaServis.Entities;
using LicitacijaServis.Models;
using LicitacijaServis.Models.Mock;
using LicitacijaServis.ServiceCalls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace LicitacijaServis.Controllers
{

    [Route("api/licitacija")]
    [ApiController]
    public class LicitacijaController : ControllerBase
    {
        private readonly ILicitacijaRepository _licitacijaRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        //private readonly IJavnoNadmetanjeMockRepository _javnoNadmetanjeMockRepository;
        private readonly IJavnoNadmetanjeService _javnoNadmetanjeService;
        public LicitacijaController(ILicitacijaRepository licitacijaRepository, IMapper mapper, LinkGenerator linkGenerator,IJavnoNadmetanjeService javnoNadmetanjeService)
        {
            _licitacijaRepository = licitacijaRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _javnoNadmetanjeService = javnoNadmetanjeService;
        }

        /// <summary>
        /// Vraća sve licitacije.
        /// </summary>
        /// <response code="200">Vraća listu licitacija.</response>
        /// /// <response code="204">Nema kontenta</response>
        /// <response code="404">Nije pronađeno nijedna licitacija</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<List<LicitacijaDto>> GetLicitacijas()
        {
            var licitacije = _mapper.Map<List<LicitacijaDto>>(_licitacijaRepository.GetLicitacijas());
            //List<JavnoNadmetanjeDto> javnaNadmetanja = _javnoNadmetanjeMockRepository.GetJavnaNadmetanja().ToList();
            foreach (var l in licitacije)
            {
                List<JavnoNadmetanjeInfoDto> listaJn = new List<JavnoNadmetanjeInfoDto>();
                foreach (var jn in l.JavnaNadmetanja)
                {
                    var javnoN = _javnoNadmetanjeService.GetJavnoNadmetanjeById(jn).Result;
                    listaJn.Add(javnoN);

                }
                l.JavnaNadmetanjaObj = listaJn;
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(licitacije);

        }

        /// <summary>
        /// Vraća jednu licitaciju na osnovu njenog ID-ja.
        /// </summary>
        /// <param name="id">ID licitacije</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženu licitaciju</response>
        /// <response code="404">Vraća da licitacija nije pronađena</response>

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<LicitacijaDto> GetLicitacijaById(Guid id)
        {
            var licitacija = _mapper.Map<LicitacijaDto>(_licitacijaRepository.GetLicitacijaById(id));
          //  List<JavnoNadmetanjeDto> javnaNadmetanja = _javnoNadmetanjeMockRepository.GetJavnaNadmetanja().ToList();
            // licitacija.JavnaNadmetanja = javnaNadmetanja;
            List<JavnoNadmetanjeInfoDto> listaJn = new List<JavnoNadmetanjeInfoDto>();
            foreach (var jn in licitacija.JavnaNadmetanja)
            {
                var javnoN = _javnoNadmetanjeService.GetJavnoNadmetanjeById(jn).Result;
                listaJn.Add(javnoN);

            }
            licitacija.JavnaNadmetanjaObj = listaJn;

            if (licitacija == null)
            {
                return NotFound();
            }
            return Ok(licitacija);
        }


        /// <summary>
        /// Vrši brisanje jedne licitacije na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="id">ID licitacije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Licitacija  uspješno obrisana</response>
        /// <response code="404">Nije pronađena licitacija za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja licitacije</response>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult DeleteLicitacija(Guid id)
        {
            
            try
            {
                var licitacije = _licitacijaRepository.GetLicitacijaById(id);

                if (licitacije == null)
                {
                    return NotFound();
                }

                _licitacijaRepository.DeleteLicitacija(id);
                _licitacijaRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }

        /// <summary>
        /// Ažurira jednu licitaciju.
        /// </summary>
        /// <param name="licitacija">Model licitacije koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj licitaciji.</returns>
        /// <response code="200">Vraća ažuriranu licitaciju</response>
        /// <response code="404">Licitacija koje se ažurira nije pronađena</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja licitacije.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicitacijaUpdateDto> UpdateLicitacija(LicitacijaUpdateDto licitacija)
        {
            try
            {
                Licitacija staraLicitacija = _licitacijaRepository.GetLicitacijaById(licitacija.LicitacijaId);
                if (staraLicitacija == null)
                {
                    return NotFound();
                }
                Licitacija novaLicitacija = _mapper.Map<Licitacija>(licitacija);
                _licitacijaRepository.UpdateLicitacija(staraLicitacija, novaLicitacija);
                return Ok(_mapper.Map<LicitacijaUpdateDto>(novaLicitacija));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja licitacije!");
            }
        }
        /// <summary>
        /// Kreiranje nove licitacije.
        /// </summary>
        /// <param name="licitacija">Model liictacije</param>
        /// <returns>Potvrdu o kreiranoj licitaciji.</returns>
        /// <remarks>
        /// Primjer zahtjeva za kreiranje nove licitacije \
        /// POST /api/licitacije \
        /// {     \
        ///     "Broj":"23", \
        ///     "Godina": "2022", \
        ///     "Ogranicenje": "100000000", \
        ///     "KorakCene":"55000", \
        ///     "ListaDokumentacijeFizickaLica":"DokumentFizicko", \
        ///     "ListaDokumentacijePravnaLica":"DokumentPravno", \
        ///     "Rok":"2022-10-14T21:56:02.868", \
        ///     "Datum":"2022-12-14T21:56:02.868", \
        ///     "JavnaNadmetanja":"4563cf92-b8d0-4574-9b40-a725f884da36", \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreiranu liictaciju</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja licitacije</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicitacijaConfirmationDto> CreateLicitacija([FromBody] LicitacijaCreationDto licitacija)
        {
            try
            {
                Licitacija licitacijaEntity = _mapper.Map<Licitacija>(licitacija);
                Licitacija lic=  _licitacijaRepository.CreateLicitacija(licitacijaEntity);
                _licitacijaRepository.SaveChanges(); //Perzistiramo promene

             

                string location = _linkGenerator.GetPathByAction("GetLicitacijas", "Licitacija", new { LicitacijaId = lic.LicitacijaId });
                return Created(location, _mapper.Map<LicitacijaConfirmationDto>(lic));

               
            }
            catch (Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }


    }
}
