using Gateway.Models.Korisnik;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Gateway.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Gateway.Logger;
using Google.Cloud.Logging.Type;
using System.Reflection;

namespace Gateway.Controllers.Korisnik
{
    [Route("api/korisnik")]
    [ApiController]
    [Produces("application/json")]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _serviceCall;
        private readonly string url = $"{StaticDetails.KorisnikService}api/korisnik/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public KorisnikController(IKorisnikService serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Menadzer,Administrator")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<KorisnikConfirmationDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var korisnici = _serviceCall.GetAsync(url).Result;
                if (korisnici == null)
                {
                    _error = $"Ne postoji nijedan korisnik";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(korisnici);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Menadzer,Administrator")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<KorisnikConfirmationDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var korisnik = _serviceCall.GetByIdAsync(url, id).Result;
                if (korisnik == null)
                {
                    _error = $"Ne postoji korisnik sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(korisnik);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Administrator")]
        [HttpPost("register")]
        public ActionResult<KorisnikTokenDto> Register(KorisnikDto korisnikDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var korisnik = _serviceCall.RegisterAsync(url + "register/", korisnikDto).Result;
                if (korisnik == null)
                {
                    _error = $"Postoji korisnik {korisnikDto.KorisnickoIme} ili tip korisnika sa ID-jem {korisnikDto.TipKorisnikaId} ne postoji";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(409, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(korisnik);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [HttpPost("login")]
        public ActionResult<KorisnikTokenDto> Login(KorisnikLoginDto korisnikDto)
        {
            string _error;
            var korisnik = _serviceCall.LoginAsync(url + "login/", korisnikDto).Result;
            if (korisnik == null)
            {
                _error = $"Neispravna lozinka ili ne postoji korisnik {korisnikDto.KorisnickoIme}";
                _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                return StatusCode(409, value: _error);
            }
            _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info); 
            return Ok(korisnik);
        }

        [AuthRole("Role", "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<KorisnikConfirmationDto> Put(int id, KorisnikDto korisnikDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var korisnik = _serviceCall.PutAsync(url, id, korisnikDto).Result;
                if (korisnik == null)
                {
                    _error = $"Vec postoji korisnik {korisnikDto.KorisnickoIme} ili ne postoji korisnik sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(korisnik);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var korisnik = _serviceCall.DeleteAsync(url, id).Result;
                if (korisnik == null)
                {
                    _error = $"Ne postoji korisnik sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(korisnik);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }
    }
}
