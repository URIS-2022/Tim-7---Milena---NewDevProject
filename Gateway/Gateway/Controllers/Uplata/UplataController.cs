using Gateway.Models.Uplata;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Gateway.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Gateway.Logger;
using Google.Cloud.Logging.Type;
using System.Reflection;

namespace Gateway.Controllers.Uplata
{
    [Route("api/uplata")]
    [ApiController]
    [Produces("application/json")]
    public class UplataController : ControllerBase
    {
        private readonly IServiceCall<UplataDto, UplataDto> _serviceCall;
        private readonly string url = $"{StaticDetails.UplataService}api/uplata/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public UplataController(IServiceCall<UplataDto, UplataDto> serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Operater")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<UplataDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var uplate = _serviceCall.GetAsync(url).Result;
                if (uplate == null)
                {
                    _error = $"Ne postoji nijedna uplata";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(uplate);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UplataDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var uplata = _serviceCall.GetByIdAsync(url, id).Result;
                if (uplata == null)
                {
                    _error = $"Ne postoji uplata sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(uplata);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater")]
        [HttpPost]
        public ActionResult<UplataDto> Post(UplataDto uplataDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var uplata = _serviceCall.PostAsync(url, uplataDto).Result;
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(uplata);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater")]
        [HttpPut("{id}")]
        public ActionResult<UplataDto> Put(int id, UplataDto uplataDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var uplata = _serviceCall.PutAsync(url, id, uplataDto).Result;
                if (uplata == null)
                {
                    _error = $"Ne postoji uplata sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(uplata);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var uplata = _serviceCall.DeleteAsync(url, id).Result;
                if (uplata == null)
                {
                    _error = $"Ne postoji uplata sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(uplata);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
