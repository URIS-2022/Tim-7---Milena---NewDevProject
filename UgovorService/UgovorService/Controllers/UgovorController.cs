﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UgovorService.Entities;
using UgovorService.Models;
using UgovorService.Repositories;
using UgovorService.ServiceCalls;

namespace UgovorService.Controllers
{
    [ApiController]
    [Route("api/ugovor")]
    public class UgovorController:ControllerBase
    {
        private readonly IUgovorRepository ugovorRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly IKupacService kupacService;
        private readonly IJavnoNadmetanjeService javnoNadmetanjeService;
        public UgovorController(IUgovorRepository ugovorRepository, IMapper mapper, LinkGenerator linkGenerator, IKupacService kupacService, IJavnoNadmetanjeService javnoNadmetanjeService)
        {
            this.ugovorRepository = ugovorRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.kupacService = kupacService;
            this.javnoNadmetanjeService = javnoNadmetanjeService;
        }

        /// <summary>
        /// Vraca sve ugovore
        /// </summary>
        /// <returns> Lista ugovora </returns>
        /// <response code="200">Vraca listu ugovora</response>
        /// <response code="404">Ne postoji nijedan ugovor</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]
        public ActionResult<List<UgovorDTO>> GetUgovore()
        {
            List<UgovorDTO> ugovori = mapper.Map<List<UgovorDTO>>(ugovorRepository.GetUgovore());
            if (ugovori == null || ugovori.Count == 0)
            {
                return NoContent();
            }
            foreach (var ugovor in ugovori)
            {
                KupacInfoDto kupac = kupacService.GetKupacById((Guid)ugovor.KupacID).Result;
                ugovor.Kupac = kupac;
                JavnoNadmetanjeInfoDTO javnoNadmetanje = javnoNadmetanjeService.GetJavnoNadmetanjeById((Guid)ugovor.JavnoNadmetanjeID).Result;
                ugovor.JavnoNadmetanje = javnoNadmetanje;

            }
            return Ok(ugovori);
        }
        /// <summary>
        /// Vraca ugovor na osnovu ID-ja .
        /// </summary>
        /// <param name="ugovorID">ID ugovora</param>
        /// <returns>Odgovarajuc ugovor</returns>
        /// <response code="200">Vraća trazen ugovor</response>
        /// <response code="404">Nije pronadjen trazen ugovor</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{ugovorID}")]
        public ActionResult<UgovorDTO> GetUgovorByID(Guid ugovorID)
        {
            var ugovor = mapper.Map<UgovorDTO>(ugovorRepository.GetUgovor(ugovorID));
            if (ugovor == null)

            {
                return NotFound();
            }
            KupacInfoDto kupac = kupacService.GetKupacById((Guid)ugovor.KupacID).Result;
            ugovor.Kupac = kupac;
            JavnoNadmetanjeInfoDTO javnoNadmetanje = javnoNadmetanjeService.GetJavnoNadmetanjeById((Guid)ugovor.JavnoNadmetanjeID).Result;
            ugovor.JavnoNadmetanje = javnoNadmetanje;

            return Ok(ugovor);

        }

        /// <summary>
        /// Kreira novi ugovor.
        /// </summary>
        
        /// <response code="201">Vraća kreirani ugovor</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja ugovora</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UgovorConfirmationDTO> CreateUgovor([FromBody] UgovorCreationDTO ugovor)
        {
            try
            {
                var z = mapper.Map<Ugovor>(ugovor);
                Ugovor confirmation = ugovorRepository.CreateUgovor(z);
                string location = linkGenerator.GetPathByAction("GetUgovore", "Ugovor", new { UgovorID = z.UgovorID });
                return Created(location, mapper.Map<UgovorConfirmationDTO>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja ugovora!");
            }
        }

        /// <summary>
        /// Vrši brisanje jednog ugovora na osnovu ID-ja.
        /// </summary>
        /// <param name="ugovorID">ID ugovora</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">ugovor obrisan</response>
        /// <response code="404">Nije pronađena ugovor za brisanjee</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja ugovora</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{ugovorID}")]
        public IActionResult DeleteUgovor(Guid ugovorID)
        {
            try
            {
                var ugovor = ugovorRepository.GetUgovor(ugovorID);

                if (ugovor == null)
                {
                    return NotFound();
                }

                ugovorRepository.DeleteUgovor(ugovorID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja ugovora");
            }
        }

        /// <summary>
        /// Ažurira jedan ugovor
        /// </summary>
        /// <returns>Potvrda o modfikovanom ugovoru</returns>
        /// <response code="200">Vraća kreiran ugovor</response>
        /// <response code="400">ugovor nije pronadjen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja ugovora</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UgovorUpdateDTO> UpdateUgovor([FromBody] UgovorUpdateDTO ugovor)
        {

            try
            {
                Ugovor stariUgovor = ugovorRepository.GetUgovor(ugovor.UgovorID);
                if (stariUgovor == null)
                {
                    return NotFound();
                }
                Ugovor noviUgovor = mapper.Map<Ugovor>(ugovor);
                ugovorRepository.UpdateUgovor(stariUgovor, noviUgovor);
                return Ok(mapper.Map<UgovorUpdateDTO>(noviUgovor));

            }
            catch (Exception)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja ugovora!");
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa ugovorom
        /// </summary>
        [HttpOptions]
        public IActionResult GetUgovorOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}
