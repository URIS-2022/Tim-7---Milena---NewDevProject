using Gateway.Helpers;
using Gateway.Logger;
using Gateway.Models.Zakup;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Google.Cloud.Logging.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Gateway.Controllers.Zakup
{
    [Route("api/dokument")]
    [ApiController]
    [Produces("application/json")]
    public class DokumentController : ControllerBase
    {
        private readonly IServiceCall<DokumentDto, DokumentConfirmationDto> _serviceCall;
        private readonly string url = $"{StaticDetails.ZakupService}api/dokument/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public DokumentController(IServiceCall<DokumentDto, DokumentConfirmationDto> serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Menadzer,Administrator,Superuser,Tehnicki sekretar")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<DokumentConfirmationDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var dokumenti = _serviceCall.GetAsync(url).Result;
                if (dokumenti == null)
                {
                    _error = $"Ne postoji nijedan dokument";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(dokumenti);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Menadzer,Administrator,Superuser,Tehnicki sekretar")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DokumentConfirmationDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var dokument = _serviceCall.GetByIdAsync(url, id).Result;
                if (dokument == null)
                {
                    _error = $"Ne postoji dokument sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(dokument);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Tehnicki sekretar")]
        [HttpPost]
        public ActionResult<DokumentDto> Post(DokumentDto dokumentDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var dokument = _serviceCall.PostAsync(url, dokumentDto).Result;
                if (dokument == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(dokument);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Tehnicki sekretar")]
        [HttpPut]
        public ActionResult<DokumentConfirmationDto> Put(int id, DokumentConfirmationDto dokumentDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var dokument = _serviceCall.PutAsync(url, id, dokumentDto).Result;
                if (dokument == null)
                {
                    _error = $"Ne postoji dokument sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                Ok(dokument);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Tehnicki sekretar")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var dokument = _serviceCall.DeleteAsync(url, id).Result;
                if (dokument == null)
                {
                    _error = $"Ne postoji dokument sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(dokument);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
