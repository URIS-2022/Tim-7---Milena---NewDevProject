﻿using Gateway.Helpers;
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
    [Route("api/fizickoLice")]
    [ApiController]
    [Produces("application/json")]
    public class FizickoLiceController : ControllerBase
    {
        private readonly IServiceCall<FizickoLiceCreationDto, FizickoLiceUpdateDto> _serviceCall;
        private readonly string url = $"{StaticDetails.LiciterService}api/fizickoLice/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private string _error;
        private readonly string _noAuth;

        public FizickoLiceController(IServiceCall<FizickoLiceCreationDto, FizickoLiceUpdateDto> serviceCall, ILoggerService loggerService)
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
        public ActionResult<List<FizickoLiceUpdateDto>> GetAll()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var fizickaLica = _serviceCall.GetAsync(url).Result;
                if (fizickaLica == null)
                {
                    _error = $"Ne postoji nijedno fizicko lice";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(fizickaLica);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Tehnicki sekretar,Superuser,Operater nadmetanja,Menadzer,Licitant")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FizickoLiceUpdateDto> Get(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var fizickoLice = _serviceCall.GetByIdAsync(url, id).Result;
                if (fizickoLice == null)
                {
                    _error = $"Ne postoji fizicko lice sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(fizickoLice);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Superuser,Operater nadmetanja")]
        [HttpPost]
        public ActionResult<FizickoLiceUpdateDto> Post(FizickoLiceCreationDto fizickoLiceDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var fizickoLice = _serviceCall.PostAsync(url, fizickoLiceDto).Result;
                if (fizickoLice == null)
                {
                    _error = "Conflict";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return Conflict();
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(fizickoLice);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Superuser,Operater nadmetanja,Tehnicki sekretar")]
        [HttpPut("{id}")]
        public ActionResult<FizickoLiceUpdateDto> Put(int id, FizickoLiceCreationDto fizickoLiceDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var fizickoLice = _serviceCall.PutAsync(url, id, fizickoLiceDto).Result;
                if (fizickoLice == null)
                {
                    _error = $"Ne postoji fizicko lice sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(fizickoLice);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Superuser,Operater nadmetanja")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var fizickoLice = _serviceCall.DeleteAsync(url, id).Result;
                if (fizickoLice == null)
                {
                    _error = $"Ne postoji fizicko lice sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(fizickoLice);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }
    }
}
