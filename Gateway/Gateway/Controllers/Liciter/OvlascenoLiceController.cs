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
    [Route("api/ovlascenoLice")]
    [ApiController]
    [Produces("application/json")]
    public class OvlascenoLiceController : ControllerBase
    {
        private readonly IServiceCall<OvlascenoLiceCreationDto, OvlascenoLiceUpdateDto> _serviceCall;
        private readonly string url = $"{StaticDetails.KupacService}api/ovlascenoLice/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public OvlascenoLiceController(IServiceCall<OvlascenoLiceCreationDto, OvlascenoLiceUpdateDto> serviceCall, ILoggerService loggerService)
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
        public ActionResult<List<OvlascenoLiceUpdateDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var ovlascenaLica = _serviceCall.GetAsync(url).Result;
                if (ovlascenaLica == null)
                {
                    _error = $"Ne postoji nijedno ovlasceno lice";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(ovlascenaLica);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Tehnicki sekretar,Superuser,Operater nadmetanja,Menadzer,Licitant")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OvlascenoLiceUpdateDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var ovlascenoLice = _serviceCall.GetByIdAsync(url, id).Result;
                if (ovlascenoLice == null)
                {
                    _error = $"Ne postoji ovlasceno lice sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(ovlascenoLice);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Superuser,Operater nadmetanja")]
        [HttpPost]
        public ActionResult<OvlascenoLiceUpdateDto> Post(OvlascenoLiceCreationDto ovlascenoLiceDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var ovlascenoLice = _serviceCall.PostAsync(url, ovlascenoLiceDto).Result;
                if (ovlascenoLice == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(ovlascenoLice);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Superuser,Operater nadmetanja,Tehnicki sekretar")]
        [HttpPut]
        public ActionResult<OvlascenoLiceUpdateDto> Put(int id, OvlascenoLiceUpdateDto ovlascenoLiceDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var ovlascenoLice = _serviceCall.PutAsync(url, id, ovlascenoLiceDto).Result;
                if (ovlascenoLice == null)
                {
                    _error = $"Ne postoji ovlasceno lice sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(ovlascenoLice);
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
                var ovlascenoLice = _serviceCall.DeleteAsync(url, id).Result;
                if (ovlascenoLice == null)
                {
                    _error = $"Ne postoji ovlasceno lice sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(ovlascenoLice);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }
    }
}
