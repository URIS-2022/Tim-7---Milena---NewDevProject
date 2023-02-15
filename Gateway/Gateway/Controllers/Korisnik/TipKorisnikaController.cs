using Gateway.Helpers;
using Gateway.Logger;
using Gateway.Models.Korisnik;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Google.Cloud.Logging.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Gateway.Controllers.Korisnik
{
    [Route("api/tipKorisnika")]
    [ApiController]
    [Produces("application/json")]
    public class TipKorisnikaController : ControllerBase
    {
        private readonly IServiceCall<TipKorisnikaDTO, TipKorisnikaConfirmationDTO> _serviceCall;
        private readonly string url = $"{StaticDetails.KorisnikService}api/tipKorisnika/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private string _error;
        private readonly string _noAuth;

        public TipKorisnikaController(IServiceCall<TipKorisnikaDTO, TipKorisnikaConfirmationDTO> serviceCall, ILoggerService loggerService)
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
        public ActionResult<List<TipKorisnikaConfirmationDTO>> GetAll()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipoviKorisnika = _serviceCall.GetAsync(url).Result;
                if (tipoviKorisnika == null)
                {
                    _error = $"Ne postoji nijedan tip korisnika";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(tipoviKorisnika);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Menadzer,Administrator")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipKorisnikaConfirmationDTO> Get(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipKorisnika = _serviceCall.GetByIdAsync(url, id).Result;
                if (tipKorisnika == null)
                {
                    _error = $"Ne postoji tip korisnika sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(tipKorisnika);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Administrator")]
        [HttpPost]
        public ActionResult<TipKorisnikaConfirmationDTO> Post(TipKorisnikaDTO tipKorisnikaDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipKorisnika = _serviceCall.PostAsync(url, tipKorisnikaDto).Result;
                if (tipKorisnika == null)
                {
                    _error = $"Postoji tip korisnika {tipKorisnikaDto.Naziv}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(409, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(tipKorisnika);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<TipKorisnikaConfirmationDTO> Put(int id, TipKorisnikaDTO tipKorisnikaDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipKorisnika = _serviceCall.PutAsync(url, id, tipKorisnikaDto).Result;
                if (tipKorisnika == null)
                {
                    _error = $"Vec postoji tip korisnika {tipKorisnikaDto.Naziv} ili ne postoji tip korisnika sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(tipKorisnika);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipKorisnika = _serviceCall.DeleteAsync(url, id).Result;
                if (tipKorisnika == null)
                {
                    _error = $"Ne postoji tip korisnika sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(tipKorisnika);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }
    }
}
