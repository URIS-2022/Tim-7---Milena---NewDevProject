using Gateway.Helpers;
using Gateway.Logger;
using Gateway.Models.Oglas;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Google.Cloud.Logging.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Gateway.Controllers.Oglas
{
    [Route("api/sluzbeniList")]
    [ApiController]
    [Produces("application/json")]
    public class SluzbeniListController : ControllerBase
    {
        private readonly IServiceCall<SluzbeniListDto, SluzbeniListGetDto> _serviceCall;
        private readonly string url = $"{StaticDetails.OglasService}api/sluzbeniList/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private string _error;
        private readonly string _noAuth;

        public SluzbeniListController(IServiceCall<SluzbeniListDto, SluzbeniListGetDto> serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Operater,Superuser,Prva komisija,Menadzer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<SluzbeniListGetDto>> GetAll()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var sluzbeniListovi = _serviceCall.GetAsync(url).Result;
                if (sluzbeniListovi == null)
                {
                    _error = $"Ne postoji nijedan sluzbeni list";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(sluzbeniListovi);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater,Superuser,Prva komisija,Menadzer,Tehnicki sekretar")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<SluzbeniListGetDto> Get(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var sluzbeniList = _serviceCall.GetByIdAsync(url, id).Result;
                if (sluzbeniList == null)
                {
                    _error = $"Ne postoji sluzbeni list sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(sluzbeniList);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater,Superuser,Prva komisija")]
        [HttpPost]
        public ActionResult<SluzbeniListGetDto> Post(SluzbeniListDto sluzbeniListDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var sluzbeniList = _serviceCall.PostAsync(url, sluzbeniListDto).Result;
                if (sluzbeniList == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(sluzbeniList);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater,Superuser,Tehnicki sekretar,Prva komisija")]
        [HttpPut("{id}")]
        public ActionResult<SluzbeniListGetDto> Put(int id, SluzbeniListDto sluzbeniListDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var sluzbeniList = _serviceCall.PutAsync(url, id, sluzbeniListDto).Result;
                if (sluzbeniList == null)
                {
                    _error = $"Ne postoji sluzbeni list sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(sluzbeniList);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater,Superuser,Prva komisija")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var sluzbeniList = _serviceCall.DeleteAsync(url, id).Result;
                if (sluzbeniList == null)
                {
                    _error = $"Ne postoji sluzbeni list sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(sluzbeniList);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
