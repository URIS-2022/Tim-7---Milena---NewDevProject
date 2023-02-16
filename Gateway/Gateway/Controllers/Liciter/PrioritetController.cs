using Gateway.Helpers;
using Gateway.Logger;
using Gateway.Models.Liciter;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Google.Cloud.Logging.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Gateway.Controllers.Liciter
{
    [Route("api/prioritet")]
    [ApiController]
    [Produces("application/json")]
    public class PrioritetController : ControllerBase
    {
        private readonly IServiceCall<PrioritetCreationDto, PrioritetUpdateDto> _serviceCall;
        private readonly string url = $"{StaticDetails.LiciterService}api/prioritet/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public PrioritetController(IServiceCall<PrioritetCreationDto, PrioritetUpdateDto> serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Menadzer,Licitant,Operater nadmetanja,Superuser")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<PrioritetUpdateDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var prioriteti = _serviceCall.GetAsync(url).Result;
                if (prioriteti == null)
                {
                    _error = $"Ne postoji nijedan prioritet";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(prioriteti);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Tehnicki sekretar,Superuser,Operater nadmetanja,Menadzer,Licitant")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PrioritetUpdateDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var prioritet = _serviceCall.GetByIdAsync(url, id).Result;
                if (prioritet == null)
                {
                    _error = $"Ne postoji prioritet sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(prioritet);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Superuser,Operater nadmetanja")]
        [HttpPost]
        public ActionResult<PrioritetUpdateDto> Post(PrioritetCreationDto prioritetDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var prioritet = _serviceCall.PostAsync(url, prioritetDto).Result;
                if (prioritet == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(prioritet);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Superuser,Operater nadmetanja,Tehnicki sekretar")]
        [HttpPut]
        public ActionResult<PrioritetUpdateDto> Put(int id, PrioritetUpdateDto prioritetDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var prioritet = _serviceCall.PutAsync(url, id, prioritetDto).Result;
                if (prioritet == null)
                {
                    _error = $"Ne postoji prioritet sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(prioritet);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Superuser,Operater nadmetanja")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var prioritet = _serviceCall.DeleteAsync(url, id).Result;
                if (prioritet == null)
                {
                    _error = $"Ne postoji prioritet sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(prioritet);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }
    }
}
