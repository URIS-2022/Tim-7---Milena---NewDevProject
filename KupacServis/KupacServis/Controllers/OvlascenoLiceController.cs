using AutoMapper;
using KupacServis.Data;
using KupacServis.Data.MockRepository;
using KupacServis.Entities;
using KupacServis.Models;
using KupacServis.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace KupacServis.Controllers
{
    [Route("api/ovlascenoLice")]
    [ApiController]
    public class OvlascenoLiceController:ControllerBase
    {
            private readonly IOvlascenoLiceRepository _ovlascenoLiceRepository;
            private readonly IMapper _mapper;
            private readonly LinkGenerator _linkGenerator;
            private readonly IKupacRepository _kupacRepository;
            private readonly IAdresaService _adresaService;
            private readonly IDrzavaService _drzavaService;
            public OvlascenoLiceController(IOvlascenoLiceRepository ovlascenoLiceRepository, IMapper mapper, LinkGenerator linkGenerator,IKupacRepository kupacRepository,IAdresaService adresaService,IDrzavaService drzavaService)
            {
                _ovlascenoLiceRepository = ovlascenoLiceRepository;
                _mapper = mapper;
                _linkGenerator = linkGenerator;
                _kupacRepository = kupacRepository;
                _adresaService = adresaService;
               _drzavaService = drzavaService;

            }


        /// <summary>
        /// Vraća sva ovlaštena lica.
        /// </summary>
        /// <response code="200">Vraća listu ovlaštenih lica</response>
        /// /// <response code="204">Nema kontenta</response>
        /// <response code="404">Nije pronađeno ovlašćeno lice</response>


        [HttpGet]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            public ActionResult<List<OvlascenoLiceDto>> GetOvlascenoLices()
            {
                var ovlascenaLica = _mapper.Map<List<OvlascenoLiceDto>>(_ovlascenoLiceRepository.GetOvlascenoLices());
            if(ovlascenaLica == null || ovlascenaLica.Count ==0)
            {
                return NoContent();
            }
                foreach (var o in ovlascenaLica)
                {
                    o.Drzava = _drzavaService.GetDrzavaByID(o.DrzavaId).Result;
                   
                    o.Adresa = _adresaService.GetAdresaByID(o.AdresaId).Result;
                }
            foreach (var ol in ovlascenaLica)
                {
                    List<KupacInfoDto> kupci = new List<KupacInfoDto>();
                    foreach (var k in ol.Kupci)
                    {
                        var lice = _mapper.Map<KupacInfoDto>(_kupacRepository.GetKupacById(k));
                        kupci.Add(lice);

                    }
                    ol.KupciObj = kupci;
                }
                 if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(ovlascenaLica);

            }


        /// <summary>
        /// Vraća jedno ovlašteno lice na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="id">ID ovlašćenog lica</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženo ovlašćeno lice</response>
        /// <response code="404">Vraća da lice nije pronađeno</response>
        [HttpGet("{id}")]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            public ActionResult<OvlascenoLiceDto> GetOvlascenoLiceById(Guid id)
            {
                var ovlascenoLice = _mapper.Map<OvlascenoLiceDto>(_ovlascenoLiceRepository.GetOvlascenoLiceById(id));
                if (ovlascenoLice == null)
                {
                    return NotFound();
                }
                 List<KupacInfoDto> kupci = new List<KupacInfoDto>();
                foreach (var k in ovlascenoLice.Kupci)
                {
                    var lice = _mapper.Map<KupacInfoDto>(_kupacRepository.GetKupacById(k));
                    kupci.Add(lice);

                }
                 ovlascenoLice.KupciObj = kupci;
              ovlascenoLice.Drzava = _drzavaService.GetDrzavaByID(ovlascenoLice.DrzavaId).Result;

                ovlascenoLice.Adresa = _adresaService.GetAdresaByID(ovlascenoLice.AdresaId).Result;


            return Ok(ovlascenoLice);
            }


        /// <summary>
        /// Vrši brisanje jednog ovlašćenog lica na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="id">ID ovlašćenog lica</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Ovlašćeno lice uspješno obrisano</response>
        /// <response code="404">Nije pronađeno ovlašteno lice za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja ovlaštenog lica</response>

        [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            [HttpDelete("{id}")]
            public IActionResult DeleteOvlascenoLice(Guid id)
            {

                try
                {
                    var ovlascenoLice = _ovlascenoLiceRepository.GetOvlascenoLiceById(id);

                    if (ovlascenoLice == null)
                    {
                        return NotFound();
                    }

                   _ovlascenoLiceRepository.DeleteOvlascenoLice(id);
                   _ovlascenoLiceRepository.SaveChanges();
                    return NoContent();
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
                }
            }

        /// <summary>
        /// Ažurira jedno fizičko lice.
        /// </summary>
        /// <param name="ovlascenoLice">Model ovlaštenog lica koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom ovlaštenom licu.</returns>
        /// <response code="200">Vraća ažurirano ovlašteno lice</response>
        /// <response code="400">Ovlašteno lice koje se ažurira nije pronađeno</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja ovlaštenog lica</response>

        [HttpPut]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public ActionResult<OvlascenoLiceUpdateDto> UpdateOvlascenoLice([FromBody] OvlascenoLiceUpdateDto ovlascenoLice)
            {
                //try
               // {
                    OvlascenoLice staroOvlascenoLice = _ovlascenoLiceRepository.GetOvlascenoLiceById(ovlascenoLice.OvlascenoLiceId);
                    if (staroOvlascenoLice == null)
                    {
                        return NotFound();
                    }
                    OvlascenoLice novoOvlascenoLice = _mapper.Map<OvlascenoLice>(ovlascenoLice);
                    _ovlascenoLiceRepository.UpdateOvlascenoLice(staroOvlascenoLice, novoOvlascenoLice);
                    return Ok(_mapper.Map<OvlascenoLiceUpdateDto>(novoOvlascenoLice));

               // }
               // catch (Exception)
               // {
               //     return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja javnog nadmetanja!");
                //}
        }

        /// <summary>
        /// Kreira novo ovlašteno lice.
        /// </summary>
        /// <param name="ovlascenoLice">Model ovlaštenog lica</param>
        /// <returns>Potvrdu o kreiranom ovlašćenom licu.</returns>
        /// <remarks>
        /// Primjer zahtjeva za kreiranje novog ovlašćenog lica \
        /// POST /api/ovlascenoLice \
        /// {     \
        ///     "Ime":"Marko", \
        ///     "Prezime": "Markovic", \
        ///     "BrTable": 2, \
        ///     "Jmbg": "0806999870000", \
        ///     "AdresaId":"3454D6E2-1BD9-4870-BFB6-26DF62C2CF5C", \
        ///     "DrzavaId":"172DA933-18D1-4B1D-BE35-0ACA1CD055AA", \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreirano ovlašćeno lice</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja ovlaštenog lica</response>

        [HttpPost]
            [Consumes("application/json")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public ActionResult<OvlascenoLiceInfoDto> CreateOvlascenoLice([FromBody] OvlascenoLiceCreationDto ovlascenoLice)
            {
                try
                {
                    OvlascenoLice ovlascenoLiceEntity = _mapper.Map<OvlascenoLice>(ovlascenoLice);
                    OvlascenoLice pri = _ovlascenoLiceRepository.CreateOvlascenoLice(ovlascenoLiceEntity);
                    _ovlascenoLiceRepository.SaveChanges(); //Perzistiramo promene



                    string location = _linkGenerator.GetPathByAction("GetOvlascenoLices", "OvlascenoLice", new { OvlascenoLiceId = pri.OvlascenoLiceId });
                    return Created(location, _mapper.Map<OvlascenoLiceInfoDto>(pri));


                }
                catch (Exception)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
                }
            }

                [HttpGet("vo/{ovlascenoLiceId}")]
                [ProducesResponseType(200)]
                [ProducesResponseType(400)]
                public ActionResult<OvlascenoLiceInfoDto> GetOvlascenoLiceByIdVO(Guid ovlascenoLiceId)
                {
                    var ovlascenoLice = _mapper.Map<OvlascenoLiceInfoDto>(_ovlascenoLiceRepository.GetOvlascenoLiceByIdVO(ovlascenoLiceId));


                    if (ovlascenoLice == null)
                    {
                        return NotFound();
                    }
                    return Ok(ovlascenoLice);
                }
        /// <summary>
        /// Vraća opcije za rad sa ovlascenim licem
        /// </summary>
        [HttpOptions]
        public IActionResult GetOvlascenLiceOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}
