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

        [HttpGet]
        public ActionResult<List<KorisnikConfirmationDTO>> Get()
        {
            var korisniciDb = _korisnikRepository.GetAll(includeProperties: "TipKorisnika");

            if (korisniciDb == null || korisniciDb.Count() == 0)
            {
                return NotFound();
            }

            var korisnici = new List<KorisnikConfirmationDTO>();
            foreach (var korisnik in korisniciDb)
                korisnici.Add(new KorisnikConfirmationDTO(korisnik));

            return Ok(korisnici);
        }

        [HttpGet("{id}")]
        public ActionResult<KorisnikConfirmationDTO> Get(int id)
        {
            var korisnikDb = _korisnikRepository.GetFirstOrDefault(x => x.Id == id, includeProperties: "TipKorisnika");
            if (korisnikDb == null)
            {
                return NotFound();
            }
            return new KorisnikConfirmationDTO(korisnikDb);
        }

        [HttpPost("register")]
        public ActionResult<KorisnikTokenDTO> Register(KorisnikDTO korisnikDto)
        {
            var korisnikDb = _korisnikRepository.GetFirstOrDefault(x => x.KorisnickoIme == korisnikDto.KorisnickoIme);
            var tipKorisnikaDb = _tipKorisnikaRepository.GetFirstOrDefault(x => x.Id == korisnikDto.TipKorisnikaId);

            if (korisnikDb != null)
            {
                return Conflict();
            }

            if (tipKorisnikaDb == null)
            {
                return NotFound();
            }

            _authHelper.CreatePasswordHash(korisnikDto.Lozinka, out byte[] passwordHash, out byte[] passwordSalt);

            KorisnikEntity korisnik = new KorisnikEntity();
            korisnik.Lozinka = korisnikDto.Lozinka;
            korisnik.KorisnickoIme = korisnikDto.KorisnickoIme;
            korisnik.Ime = korisnikDto.Ime;
            korisnik.Prezime = korisnikDto.Prezime;
            korisnik.LozinkaHash = passwordHash;
            korisnik.LozinkaSalt = passwordSalt;
            korisnik.TipKorisnika = _tipKorisnikaRepository.GetFirstOrDefault(x => x.Id == korisnikDto.TipKorisnikaId);

            _korisnikRepository.Add(korisnik);
            _korisnikRepository.Save();

            string token = _authHelper.CreateToken(korisnik);

            return Ok(new KorisnikTokenDTO(korisnik, token));
        }

        [HttpPost("login")]
        public ActionResult<KorisnikTokenDTO> Login(KorisnikLoginDTO korisnikDto)
        {
            var korisnikDb = _korisnikRepository.GetFirstOrDefault(u => u.KorisnickoIme == korisnikDto.KorisnickoIme, includeProperties: "TipKorisnika");

            if (korisnikDb != null)
            {
                if (_authHelper.VerifyPasswordHash(korisnikDto.Lozinka, korisnikDb.LozinkaHash, korisnikDb.LozinkaSalt))
                {
                    string token = _authHelper.CreateToken(korisnikDb);

                    return Ok(new KorisnikTokenDTO(korisnikDb, token));
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<KorisnikConfirmationDTO> Put(int id, KorisnikDTO korisnik)
        {
            var korisnikDb = _korisnikRepository.GetFirstOrDefault(x => x.Id == id);
            var tipKorisnikaDb = _tipKorisnikaRepository.GetFirstOrDefault(x => x.Id == korisnik.TipKorisnikaId);

            if (korisnikDb == null || tipKorisnikaDb == null)
                return NotFound();

            korisnikDb.KorisnickoIme = korisnik.KorisnickoIme;
            korisnikDb.Ime = korisnik.Ime;
            korisnikDb.Prezime= korisnik.Prezime;
            korisnikDb.Lozinka = korisnik.Lozinka;
            korisnikDb.TipKorisnika = tipKorisnikaDb;
            _korisnikRepository.Save();

            return Ok(new KorisnikConfirmationDTO(korisnikDb));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var korisnikDb = _korisnikRepository.GetFirstOrDefault(x => x.Id == id);

            if (korisnikDb == null)
                return NotFound();

            _korisnikRepository.Remove(korisnikDb);
            _korisnikRepository.Save();

            return Ok($"Uspesno obrisan korisnik sa ID-jem {id} - {korisnikDb.KorisnickoIme}");
        }
    }
}
