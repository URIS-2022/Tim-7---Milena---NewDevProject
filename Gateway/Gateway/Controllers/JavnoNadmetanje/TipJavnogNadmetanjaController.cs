using Gateway.Helpers;
using Gateway.Logger;
using Gateway.Models.JavnoNadmetanje;
using Gateway.Models.Zakup;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Google.Cloud.Logging.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Gateway.Controllers.JavnoNadmetanje
{
    [Route("api/tipJavnogNadmetanja")]
    [ApiController]
    [Produces("application/json")]
    public class TipJavnogNadmetanjaController : ControllerBase
    {
        private readonly IServiceCall<TipJavnogNadmetanjaCreationDto, TipJavnogNadmetanjaDto> _serviceCall;
        private readonly string url = $"{StaticDetails.NadmetanjeService}api/tipJavnogNadmetanja/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public TipJavnogNadmetanjaController(IServiceCall<TipJavnogNadmetanjaCreationDto, TipJavnogNadmetanjaDto> serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Menadzer,Administrator,Superuser,Operater nadmetanja")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<TipJavnogNadmetanjaDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipoviJavnogNadmetanja = _serviceCall.GetAsync(url).Result;
                if (tipoviJavnogNadmetanja == null)
                {
                    _error = $"Ne postoji nijedan tip javnog nadmetanja";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(tipoviJavnogNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Menadzer,Administrator,Superuser,Operater nadmetanja")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TipJavnogNadmetanjaDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipJavnogNadmetanja = _serviceCall.GetByIdAsync(url, id).Result;
                if (tipJavnogNadmetanja == null)
                {
                    _error = $"Ne postoji tip javnogNadmetanja sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(tipJavnogNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpPost]
        public ActionResult<TipJavnogNadmetanjaCreationDto> Post(TipJavnogNadmetanjaCreationDto tipJavnogNadmetanjaDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipJavnogNadmetanja = _serviceCall.PostAsync(url, tipJavnogNadmetanjaDto).Result;
                if (tipJavnogNadmetanja == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(tipJavnogNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpPut]
        public ActionResult<TipJavnogNadmetanjaDto> Put(int id, TipJavnogNadmetanjaDto tipJavnogNadmetanjaDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipJavnogNadmetanja = _serviceCall.PutAsync(url, id, tipJavnogNadmetanjaDto).Result;
                if (tipJavnogNadmetanja == null)
                {
                    _error = $"Ne postoji tip javnog nadmetanja sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(tipJavnogNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var tipJavnogNadmetanja = _serviceCall.DeleteAsync(url, id).Result;
                if (tipJavnogNadmetanja == null)
                {
                    _error = $"Ne postoji tip javnog nadmetanja sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(tipJavnogNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
