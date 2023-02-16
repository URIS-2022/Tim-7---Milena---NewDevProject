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
    [Route("api/javnoNadmetanje")]
    [ApiController]
    [Produces("application/json")]
    public class JavnoNadmetanjeController : ControllerBase
    {
        private readonly IServiceCall<JavnoNadmetanjeCreationDto, JavnoNadmetanjeDto> _serviceCall;
        private readonly string url = $"{StaticDetails.NadmetanjeService}api/javnoNadmetanje/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public JavnoNadmetanjeController(IServiceCall<JavnoNadmetanjeCreationDto, JavnoNadmetanjeDto> serviceCall, ILoggerService loggerService)
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
        public ActionResult<List<JavnoNadmetanjeDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var javnaNadmetanja = _serviceCall.GetAsync(url).Result;
                if (javnaNadmetanja == null)
                {
                    _error = $"Ne postoji nijedno javno nadmetanje";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(javnaNadmetanja);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Menadzer,Administrator,Superuser,Operater nadmetanja")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<JavnoNadmetanjeDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var javnoNadmetanje = _serviceCall.GetByIdAsync(url, id).Result;
                if (javnoNadmetanje == null)
                {
                    _error = $"Ne postoji javno nadmetanje sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(javnoNadmetanje);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpPost]
        public ActionResult<JavnoNadmetanjeCreationDto> Post(JavnoNadmetanjeCreationDto javnoNadmetanjeDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var javnoNadmetanje = _serviceCall.PostAsync(url, javnoNadmetanjeDto).Result;
                if (javnoNadmetanje == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(javnoNadmetanje);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpPut]
        public ActionResult<JavnoNadmetanjeDto> Put(int id, JavnoNadmetanjeDto javnoNadmetanjeDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var javnoNadmetanje = _serviceCall.PutAsync(url, id, javnoNadmetanjeDto).Result;
                if (javnoNadmetanje == null)
                {
                    _error = $"Ne postoji javno nadmetanje sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(javnoNadmetanje);
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
                var javnoNadmetanje = _serviceCall.DeleteAsync(url, id).Result;
                if (javnoNadmetanje == null)
                {
                    _error = $"Ne postoji javno nadmetanje sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(javnoNadmetanje);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
