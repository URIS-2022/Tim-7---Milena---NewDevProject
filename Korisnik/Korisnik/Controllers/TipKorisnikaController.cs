using Korisnik.Entities;
using Korisnik.Models;
using Korisnik.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Korisnik.Controllers
{
    [Route("api/tipKorisnika")]
    [ApiController]
    [Produces("application/json")]
    public class TipKorisnikaController : ControllerBase
    {
        private readonly IRepository<TipKorisnikaEntity> _tipKorisnikaRepository;

        public TipKorisnikaController(IRepository<TipKorisnikaEntity> tipKorisnikaRepository)
        {
            _tipKorisnikaRepository = tipKorisnikaRepository;
        }

        /// <summary>
        /// Vraca sve tipove korisnika
        /// </summary>
        /// <returns>Lista tipova korisnika</returns>
        /// <response code="200">Vraca sve tipove korisnika</response>
        /// <response code="204">Ako ne postoji nijedan tip korisnika u bazi</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<List<TipKorisnikaConfirmationDto>> Get()
        {
            var tipoviKorisnikaDb = _tipKorisnikaRepository.GetAll();

            if (tipoviKorisnikaDb == null || !tipoviKorisnikaDb.Any())
            {
                return NoContent();
            }

            var tipoviKorisnika = new List<TipKorisnikaConfirmationDto>();
            foreach (var tipKorisnika in tipoviKorisnikaDb)
                tipoviKorisnika.Add(new TipKorisnikaConfirmationDto(tipKorisnika));

            return Ok(tipoviKorisnika);
        }

        /// <summary>
        /// Vraca odredjenog tipa korisnika 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vraca tipa korisnika po proslednjenom ID-ju</returns>
        /// <remarks>
        /// <response code="200">Vraca tipa korisnika sa prosledjenim ID-jem</response>
        /// <response code="204">Ako ne postoji tip korisnika sa prosledjenim ID-jem</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<TipKorisnikaConfirmationDto> Get(int id)
        {
            var tipKorisnikaDb = _tipKorisnikaRepository.GetFirstOrDefault(x => x.Id == id);
            if (tipKorisnikaDb == null)
            {
                return NoContent();
            }
            return new TipKorisnikaConfirmationDto(tipKorisnikaDb);
        }

        /// <summary>
        /// Kreira novog tipa korisnika
        /// </summary>
        /// <param name="tipKorisnikaDto"></param>
        /// <returns>Vraca novokreiranog tipa korisnika</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/tipKorisnika
        ///     {
        ///        "naziv": "Operater"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Vraca novokreiranog tipa korisnika</response>
        /// <response code="409">Ako vec postoji tip korisnika sa tim imenom</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<TipKorisnikaConfirmationDto> Post(TipKorisnikaDto tipKorisnikaDto)
        {
            var tipKorisnikaDb = _tipKorisnikaRepository.GetFirstOrDefault(x => x.Naziv == tipKorisnikaDto.Naziv);

            if (tipKorisnikaDb != null)
            {
                return Conflict();
            }

            TipKorisnikaEntity tipKorisnika = new TipKorisnikaEntity();
            tipKorisnika.Naziv = tipKorisnikaDto.Naziv!;

            _tipKorisnikaRepository.Add(tipKorisnika);
            _tipKorisnikaRepository.Save();

            return Ok(new TipKorisnikaConfirmationDto(tipKorisnika));
        }

        /// <summary>
        /// Modifikuje postojeceg tipa korisnika
        /// </summary>
        /// <param name="tipKorisnika"></param>
        /// <returns>Vraca modifikovanog tipa korisnika</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/tipKorisnika/2
        ///     {
        ///        "naziv": "Operater"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Vraca modifikovanog tipa korisnika</response>
        /// <response code="204">Ako ne postoji tip korisnika sa prosledjenim ID-jem</response>
        /// <response code="409">Ako vec postoji tip korisnika sa tim imenom</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<TipKorisnikaConfirmationDto> Put(int id, TipKorisnikaDto tipKorisnika)
        {
            var tipKorisnikaDb = _tipKorisnikaRepository.GetFirstOrDefault(x => x.Id == id);
            if (tipKorisnikaDb == null)
                return NoContent();
            if (_tipKorisnikaRepository.GetFirstOrDefault(x => x.Naziv == tipKorisnika.Naziv) != null)
                return Conflict();

            tipKorisnikaDb.Naziv = tipKorisnika.Naziv!;
            _tipKorisnikaRepository.Save();

            return Ok(new TipKorisnikaConfirmationDto(tipKorisnikaDb));
        }

        /// <summary>
        /// Brise postojeceg tipa korisnika
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Brise postojeceg tipa korisnika</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/tipKorisnika/1
        ///
        /// </remarks>
        /// <response code="200">Uspesno obrisan tipa korisnika</response>
        /// <response code="204">Ako ne postoji tip korisnika sa prosledjenim ID-jem</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<TipKorisnikaEntity> Delete(int id)
        {
            var tipKorisnikaDb = _tipKorisnikaRepository.GetFirstOrDefault(x => x.Id == id);

            if (tipKorisnikaDb == null)
                return NoContent();

            _tipKorisnikaRepository.Remove(tipKorisnikaDb);
            _tipKorisnikaRepository.Save();

            return Ok($"Uspesno obrisan tip korisnika sa ID-jem {id} - {tipKorisnikaDb.Naziv}");
        }
    }
}
