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
    [Route("api/oglas")]
    [ApiController]
    [Produces("application/json")]
    public class OglasController : ControllerBase
    {
        private readonly IServiceCall<OglasDto, OglasDto> _serviceCall;
        private readonly string url = $"{StaticDetails.OglasService}api/oglas/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private string _error;
        private readonly string _noAuth;

        public OglasController(IServiceCall<OglasDto, OglasDto> serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Operater,Superuser,Prva oglas,Menadzer")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<OglasDto>> GetAll()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var oglasi = _serviceCall.GetAsync(url).Result;
                if (oglasi == null)
                {
                    _error = $"Ne postoji nijedan oglas";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(oglasi);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater,Superuser,Prva oglas,Menadzer,Tehnicki sekretar")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OglasDto> Get(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var oglas = _serviceCall.GetByIdAsync(url, id).Result;
                if (oglas == null)
                {
                    _error = $"Ne postoji oglas sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(oglas);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater,Superuser,Prva oglas")]
        [HttpPost]
        public ActionResult<OglasDto> Post(OglasDto oglasDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var oglas = _serviceCall.PostAsync(url, oglasDto).Result;
                if (oglas == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(oglas);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater,Superuser,Tehnicki sekretar,Prva oglas")]
        [HttpPut("{id}")]
        public ActionResult<OglasDto> Put(int id, OglasDto oglasDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var oglas = _serviceCall.PutAsync(url, id, oglasDto).Result;
                if (oglas == null)
                {
                    _error = $"Ne postoji oglas sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(oglas);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Operater,Superuser,Prva oglas")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var oglas = _serviceCall.DeleteAsync(url, id).Result;
                if (oglas == null)
                {
                    _error = $"Ne postoji oglas sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(oglas);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
