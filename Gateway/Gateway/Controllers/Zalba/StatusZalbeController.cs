using Gateway.Helpers;
using Gateway.Logger;
using Gateway.Models.Zalba;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Google.Cloud.Logging.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Gateway.Controllers.Zalba
{
    [Route("api/statusZalbe")]
    [ApiController]
    [Produces("application/json")]
    public class StatusZalbeController : ControllerBase
    {
        private readonly IServiceCall<StatusZalbeCreationDTO, StatusZalbeDTO> _serviceCall;
        private readonly string url = $"{StaticDetails.ZalbaService}api/statusZalbe/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private string _error;
        private readonly string _noAuth;

        public StatusZalbeController(IServiceCall<StatusZalbeCreationDTO, StatusZalbeDTO> serviceCall, ILoggerService loggerService)
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
        public ActionResult<List<StatusZalbeDTO>> GetAll()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var statusiZalbe = _serviceCall.GetAsync(url).Result;
                if (statusiZalbe == null)
                {
                    _error = $"Ne postoji nijedan status zalbe";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(statusiZalbe);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Menadzer,Administrator,Superuser,Operater nadmetanja")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StatusZalbeDTO> Get(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var statusZalbe = _serviceCall.GetByIdAsync(url, id).Result;
                if (statusZalbe == null)
                {
                    _error = $"Ne postoji status zalbe sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(statusZalbe);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpPost]
        public ActionResult<StatusZalbeDTO> Post(StatusZalbeCreationDTO statusZalbeDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var statusZalbe = _serviceCall.PostAsync(url, statusZalbeDto).Result;
                if (statusZalbe == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(statusZalbe);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpPut]
        public ActionResult<StatusZalbeDTO> Put(int id, StatusZalbeDTO statusZalbeDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var statusZalbe = _serviceCall.PutAsync(url, id, statusZalbeDto).Result;
                if (statusZalbe == null)
                {
                    _error = $"Ne postoji status zalbe sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(statusZalbe);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Administrator,Superuser,Operater nadmetanja")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var statusZalbe = _serviceCall.DeleteAsync(url, id).Result;
                if (statusZalbe == null)
                {
                    _error = $"Ne postoji status zalbe sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(statusZalbe);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
