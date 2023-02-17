using Korisnik.Entities;
using Korisnik.Helpers;
using Korisnik.Models;
using Korisnik.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Korisnik.Controllers
{
    [Route("api/korisnik")]
    [ApiController]
    [Produces("application/json")]
    public class KorisnikController : ControllerBase
    {
        private readonly IRepository<KorisnikEntity> _korisnikRepository;
        private readonly IRepository<TipKorisnikaEntity> _tipKorisnikaRepository;
        private readonly IAuthHelper _authHelper;

        public KorisnikController(IRepository<KorisnikEntity> korisnikRepository, IAuthHelper authHelper, IRepository<TipKorisnikaEntity> tipKorisnikaRepository)
        {
            _korisnikRepository = korisnikRepository;
            _tipKorisnikaRepository = tipKorisnikaRepository;
            _authHelper = authHelper;
        }

        /// <summary>
        /// Vraca sve korisnike
        /// </summary>
        /// <returns>Lista korisnika</returns>
        /// <response code="200">Vraca sve korisnike</response>
        /// <response code="204">Ako ne postoji nijedan korisnik u bazi</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KorisnikConfirmationDto>> Get()
        {
            var korisniciDb = _korisnikRepository.GetAll(includeProperties: "TipKorisnika");

            if (korisniciDb == null || !korisniciDb.Any())
            {
                return NoContent();
            }

            var korisnici = new List<KorisnikConfirmationDto>();
            foreach (var korisnik in korisniciDb)
                korisnici.Add(new KorisnikConfirmationDto(korisnik));

            return Ok(korisnici);
        }

        /// <summary>
        /// Vraca odredjenog korisnika 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vraca korisnika po proslednjenom ID-ju</returns>
        /// <remarks>
        /// <response code="200">Vraca korisnika sa prosledjenim ID-jem</response>
        /// <response code="204">Ako ne postoji korisnik sa prosledjenim ID-jem</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<KorisnikConfirmationDto> Get(int id)
        {
            var korisnikDb = _korisnikRepository.GetFirstOrDefault(x => x.Id == id, includeProperties: "TipKorisnika");
            if (korisnikDb == null)
            {
                return NoContent();
            }
            return new KorisnikConfirmationDto(korisnikDb);
        }

        /// <summary>
        /// Kreira novog korisnika
        /// </summary>
        /// <param name="korisnikDto"></param>
        /// <returns>Vraca novokreiranog korisnika</returns>
        /// <response code="200">Vraca novokreiranog korisnika</response>
        /// <response code="409">Ako vec postoji korisnik sa tim korisnickim imenom</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<KorisnikTokenDto> Register(KorisnikDto korisnikDto)
        {
            var korisnikDb = _korisnikRepository.GetFirstOrDefault(x => x.KorisnickoIme == korisnikDto.KorisnickoIme);
            var tipKorisnikaDb = _tipKorisnikaRepository.GetFirstOrDefault(x => x.Id == korisnikDto.TipKorisnikaId);

            if (korisnikDb != null)
            {
                return Conflict();
            }

            if (tipKorisnikaDb == null)
            {
                return NoContent();
            }

            _authHelper.CreatePasswordHash(korisnikDto.Lozinka, out byte[] passwordHash, out byte[] passwordSalt);

            KorisnikEntity korisnik = new()
            {
                KorisnickoIme = korisnikDto.KorisnickoIme!,
                Ime = korisnikDto.Ime!,
                Prezime = korisnikDto.Prezime!,
                LozinkaHash = passwordHash,
                LozinkaSalt = passwordSalt,
                TipKorisnika = _tipKorisnikaRepository.GetFirstOrDefault(x => x.Id == korisnikDto.TipKorisnikaId)
            };

            _korisnikRepository.Add(korisnik);
            _korisnikRepository.Save();

            string token = _authHelper.CreateToken(korisnik);

            return Ok(new KorisnikTokenDto(korisnik, token));
        }

        /// <summary>
        /// Loguje postojeceg korisnika
        /// </summary>
        /// <param name="korisnikDto"></param>
        /// <returns>Vraca ulogovanog korisnika</returns>
        /// <response code="200">Vraca ulogovanog korisnika</response>
        /// <response code="204">Ako ne postoji korisnik sa tim korisnickim imenom ili je lozinka pogresna</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<KorisnikTokenDto> Login(KorisnikLoginDto korisnikDto)
        {
            var korisnikDb = _korisnikRepository.GetFirstOrDefault(u => u.KorisnickoIme == korisnikDto.KorisnickoIme, includeProperties: "TipKorisnika");

            if (korisnikDb != null)
            {
                if (_authHelper.VerifyPasswordHash(korisnikDto.Lozinka!, korisnikDb.LozinkaHash, korisnikDb.LozinkaSalt))
                {
                    string token = _authHelper.CreateToken(korisnikDb);

                    return Ok(new KorisnikTokenDto(korisnikDb, token));
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Modifikuje postojeceg korisnika
        /// </summary>
        /// <param name="korisnik"></param>
        /// <returns>Vraca modifikovanog korisnika</returns>
        /// <response code="200">Vraca modifikovanog korisnika</response>
        /// <response code="204">Ako ne postoji korisnik sa prosledjenim ID-jem</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<KorisnikConfirmationDto> Put(int id, KorisnikDto korisnik)
        {
            var korisnikDb = _korisnikRepository.GetFirstOrDefault(x => x.Id == id);
            var tipKorisnikaDb = _tipKorisnikaRepository.GetFirstOrDefault(x => x.Id == korisnik.TipKorisnikaId);

            if (korisnikDb == null || tipKorisnikaDb == null)
                return NoContent();

            korisnikDb.KorisnickoIme = korisnik.KorisnickoIme!;
            korisnikDb.Ime = korisnik.Ime!;
            korisnikDb.Prezime= korisnik.Prezime!;
            korisnikDb.TipKorisnika = tipKorisnikaDb;
            _korisnikRepository.Save();

            return Ok(new KorisnikConfirmationDto(korisnikDb));
        }

        /// <summary>
        /// Brise postojeceg korisnika
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Brise postojeceg korisnika</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /api/korisnik/1
        ///
        /// </remarks>
        /// <response code="200">Uspesno obrisan korisnik</response>
        /// <response code="204">Ako ne postoji korisnik sa prosledjenim ID-jem</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<string> Delete(int id)
        {
            var korisnikDb = _korisnikRepository.GetFirstOrDefault(x => x.Id == id);

            if (korisnikDb == null)
                return NoContent();

            _korisnikRepository.Remove(korisnikDb);
            _korisnikRepository.Save();

            return Ok($"Uspesno obrisan korisnik sa ID-jem {id} - {korisnikDb.KorisnickoIme}");
        }
    }
}
