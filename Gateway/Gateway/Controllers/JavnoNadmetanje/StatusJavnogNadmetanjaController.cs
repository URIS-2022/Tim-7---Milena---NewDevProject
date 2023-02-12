using Gateway.Helpers;
using Gateway.Logger;
using Gateway.Models.JavnoNadmetanje;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Google.Cloud.Logging.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Gateway.Controllers.JavnoNadmetanje
{
    [Route("api/statusJavnogNadmetanja")]
    [ApiController]
    [Produces("application/json")]
    public class StatusJavnogNadmetanjaController : ControllerBase
    {
        private readonly IServiceCall<StatusJavnogNadmetanjaCreationDTO, StatusJavnogNadmetanjaDTO> _serviceCall;
        private readonly string url = $"{StaticDetails.NadmetanjeService}api/statusJavnogNadmetanja/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private string _error;
        private readonly string _noAuth;

        public StatusJavnogNadmetanjaController(IServiceCall<StatusJavnogNadmetanjaCreationDTO, StatusJavnogNadmetanjaDTO> serviceCall, ILoggerService loggerService)
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
        public ActionResult<List<StatusJavnogNadmetanjaDTO>> GetAll()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var statusiJavnogNadmetanja = _serviceCall.GetAsync(url).Result;
                if (statusiJavnogNadmetanja == null)
                {
                    _error = $"Ne postoji nijedan status javnog nadmetanja";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(statusiJavnogNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Menadzer,Administrator")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StatusJavnogNadmetanjaDTO> Get(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var statusJavnogNadmetanja = _serviceCall.GetByIdAsync(url, id).Result;
                if (statusJavnogNadmetanja == null)
                {
                    _error = $"Ne postoji status javnog nadmetanja sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(statusJavnogNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator")]
        [HttpPost]
        public ActionResult<StatusJavnogNadmetanjaCreationDTO> Post(StatusJavnogNadmetanjaCreationDTO statusJavnogNadmetanjaDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var statusJavnogNadmetanja = _serviceCall.PostAsync(url, statusJavnogNadmetanjaDto).Result;
                if (statusJavnogNadmetanja == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(statusJavnogNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<StatusJavnogNadmetanjaDTO> Put(int id, StatusJavnogNadmetanjaCreationDTO statusJavnogNadmetanjaDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var statusJavnogNadmetanja = _serviceCall.PutAsync(url, id, statusJavnogNadmetanjaDto).Result;
                if (statusJavnogNadmetanja == null)
                {
                    _error = $"Ne postoji status javnog nadmetanja sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(statusJavnogNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var statusJavnogNadmetanja = _serviceCall.DeleteAsync(url, id).Result;
                if (statusJavnogNadmetanja == null)
                {
                    _error = $"Ne postoji status javnog nadmetanja sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(statusJavnogNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
