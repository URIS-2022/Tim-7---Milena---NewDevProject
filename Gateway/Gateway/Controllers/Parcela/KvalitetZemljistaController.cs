using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Gateway.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Gateway.Models.Parcela;
using Gateway.Logger;
using Google.Cloud.Logging.Type;
using System.Reflection;

namespace Gateway.Controllers.Parcela
{
    [Route("api/kvalitetZemljista")]
    [ApiController]
    [Produces("application/json")]
    public class KvalitetZemljistaController : ControllerBase
    {
        private readonly IServiceCall<KvalitetZemljistaDto, KvalitetZemljistaDto> _serviceCall;
        private readonly string url = $"{StaticDetails.ParcelaService}api/kvalitetZemljista/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private readonly string _noAuth;

        public KvalitetZemljistaController(IServiceCall<KvalitetZemljistaDto, KvalitetZemljistaDto> serviceCall, ILoggerService loggerService)
        {
            _serviceCall = serviceCall;
            _loggerService = loggerService;
            _controllerName = this.GetType().Name;
            _noAuth = "Niste ulogovani";
        }

        [AuthRole("Role", "Superuser")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<KvalitetZemljistaDto>> GetAll()
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var kvalitetiZemljista = _serviceCall.GetAsync(url).Result;
                if (kvalitetiZemljista == null)
                {
                    _error = $"Ne postoji nijedno zemljiste";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(kvalitetiZemljista);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Superuser")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<KvalitetZemljistaDto> Get(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var kvalitetZemljista = _serviceCall.GetByIdAsync(url, id).Result;
                if (kvalitetZemljista == null)
                {
                    _error = $"Ne postoji zemljiste sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(kvalitetZemljista);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Superuser")]
        [HttpPost]
        public ActionResult<KvalitetZemljistaDto> Post(KvalitetZemljistaDto kvalitetZemljistaDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var kvalitetZemljista = _serviceCall.PostAsync(url, kvalitetZemljistaDto).Result;
                if (kvalitetZemljista == null)
                {
                    _error = $"Postoji zemljiste {kvalitetZemljistaDto.NazivVrsteZemljista}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(409, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(kvalitetZemljista);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Superuser")]
        [HttpPut("{id}")]
        public ActionResult<KvalitetZemljistaDto> Put(int id, KvalitetZemljistaDto kvalitetZemljistaDto)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var kvalitetZemljista = _serviceCall.PutAsync(url, id, kvalitetZemljistaDto).Result;
                if (kvalitetZemljista == null)
                {
                    _error = $"Vec postoji zemljiste {kvalitetZemljistaDto.NazivVrsteZemljista} ili ne postoji zemljiste sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(kvalitetZemljista);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }

        [AuthRole("Role", "Superuser")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            string _error;
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var kvalitetZemljista = _serviceCall.DeleteAsync(url, id).Result;
                if (kvalitetZemljista == null)
                {
                    _error = $"Ne postoji kvalitetZemljista sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod()!.Name, _controllerName, LogSeverity.Info);
                return Ok(kvalitetZemljista);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, "Niste ulogovani");
        }
    }
}
