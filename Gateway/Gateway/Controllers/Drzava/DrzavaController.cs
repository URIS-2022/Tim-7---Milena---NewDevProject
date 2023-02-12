﻿using Gateway.Helpers;
using Gateway.Logger;
using Gateway.Models.Drzava;
using Gateway.ServiceCalls.Interfaces;
using Gateway.Utility;
using Google.Cloud.Logging.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Reflection;

namespace Gateway.Controllers.Drzava
{
    [Route("api/drzava")]
    [ApiController]
    [Produces("application/json")]
    public class DrzavaController : ControllerBase
    {
        private readonly IServiceCall<DrzavaDTO, DrzavaConfirmationDTO> _serviceCall;
        private readonly string url = $"{StaticDetails.DrzavaService}api/drzava/";
        private readonly ILoggerService _loggerService;
        private readonly string _controllerName;
        private string _error;
        private readonly string _noAuth;

        public DrzavaController(IServiceCall<DrzavaDTO, DrzavaConfirmationDTO> serviceCall, ILoggerService loggerService)
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
        public ActionResult<List<DrzavaConfirmationDTO>> GetAll()
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var drzave = _serviceCall.GetAsync(url).Result;
                if (drzave == null)
                {
                    _error = $"Ne postoji nijedna drzava";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(drzave);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Menadzer,Administrator")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<DrzavaConfirmationDTO> Get(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var drzava = _serviceCall.GetByIdAsync(url, id).Result;
                if (drzava == null)
                {
                    _error = $"Ne postoji drzava sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(drzava);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Administrator")]
        [HttpPost]
        public ActionResult<DrzavaConfirmationDTO> Post(DrzavaDTO drzavaDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var drzava = _serviceCall.PostAsync(url, drzavaDto).Result;
                if (drzava == null)
                {
                    _error = $"Postoji drzava {drzavaDto.NazivDrzave}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(409, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(drzava);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<DrzavaConfirmationDTO> Put(int id, DrzavaDTO drzavaDto)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var drzava = _serviceCall.PutAsync(url, id, drzavaDto).Result;
                if (drzava == null)
                {
                    _error = $"Vec postoji drzava {drzavaDto.NazivDrzave} ili ne postoji drzava sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(404, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(drzava);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }

        [AuthRole("Role", "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                var drzava = _serviceCall.DeleteAsync(url, id).Result;
                if (drzava == null)
                {
                    _error = $"Ne postoji drzava sa ID-jem {id}";
                    _loggerService.WriteLog(_error, _controllerName, LogSeverity.Error);
                    return StatusCode(204, value: _error);
                }
                _loggerService.WriteLog(MethodBase.GetCurrentMethod().Name, _controllerName, LogSeverity.Info);
                return Ok(drzava);
            }
            _loggerService.WriteLog(_noAuth, _controllerName, LogSeverity.Error);
            return StatusCode(StatusCodes.Status400BadRequest, _noAuth);
        }
    }
}
