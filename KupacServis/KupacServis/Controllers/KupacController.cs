using AutoMapper;
using KupacServis.Data;
using KupacServis.Data.MockRepository;
using KupacServis.Entities;
using KupacServis.Models;
using KupacServis.Models.Mock;
using KupacServis.ServiceCalls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace KupacServis.Controllers
{
    [Route("api/kupac")]
    [ApiController]
    public class KupacController : ControllerBase
    {

        private readonly IKupacRepository _kupacRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        //private readonly IJavnoNadmetanjeRepository _javnoNadmetanjeRepository;
       // private readonly IUplataRepository _uplataRepository;
        private readonly IOvlascenoLiceRepository _ovlascenoLiceRepository;
        // private readonly IAdresaRepository _adresaRepository;
        private readonly IAdresaService _adresaService;
        private readonly IJavnoNadmetanjeService _javnoNadmetanjeService;
        private readonly IUplataService _uplataService;


        public KupacController(IKupacRepository kupacRepository, IMapper mapper, LinkGenerator linkGenerator, IUplataService uplataService,IAdresaService adresaService, IOvlascenoLiceRepository ovlascenoLiceRepository,IJavnoNadmetanjeService javnoNadmetanjeService)
        {
            _kupacRepository = kupacRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            // _javnoNadmetanjeRepository = javnoNadmetanjeRepository;
            //_uplataRepository = uplataRepository;
            _uplataService = uplataService;
            _adresaService = adresaService;
            _ovlascenoLiceRepository = ovlascenoLiceRepository;
            _javnoNadmetanjeService = javnoNadmetanjeService;
        }

        /// <summary>
        /// Vraća sve kupce.
        /// </summary>
        /// <response code="200">Vraća listu kupaca</response>
        /// /// <response code="204">Nema kontenta</response>
        /// <response code="404">Nije pronađen nijedan kupac</response>

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KupacDto>> GetKupacs()
        {
            var kupci = _mapper.Map<List<KupacDto>>(_kupacRepository.GetKupacs());
            //  List<JavnoNadmetanjeDto> javnaNadmetanja = _javnoNadmetanjeRepository.GetJavnaNadmetanja().ToList();
           
            if(kupci.Count == 0 || kupci == null  )
            {
                return NoContent();
            }

           
            foreach (var k in kupci)
            {
               
                k.Adresa = _adresaService.GetAdresaByID(k.AdresaId).Result;
              
            }

            foreach (var k in kupci)
            {
                List<OvlascenoLiceInfoDto> listaOL = new List<OvlascenoLiceInfoDto>();
                foreach (var ol in k.OvlascenaLica)
                {
                    var lice = _mapper.Map<OvlascenoLiceInfoDto>(_ovlascenoLiceRepository.GetOvlascenoLiceById(ol));
                    listaOL.Add(lice);

                }
                k.OvlascenaLicaObj = listaOL;
            }
            foreach (var k in kupci)
            {
                List<JavnoNadmetanjeInfoDto> listaJn = new List<JavnoNadmetanjeInfoDto>();
                foreach (var jn in k.JavnaNadmetanja)
                {
                    var javN = _javnoNadmetanjeService.GetJavnoNadmetanjeById(jn).Result;
                    listaJn.Add(javN);

                }
                k.JavnaNadmetanjaOb = listaJn;
            }

            foreach (var k in kupci)
            {
               var uplate1 = _uplataService.GetUplataByKupacID(k.KupacId).Result;
                k.Uplate = uplate1;
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(kupci);

        }

        /// <summary>
        /// Vraća jednog kupca na osnovu njegovog  ID-ja .
        /// </summary>
        /// <param name="id">ID kupca</param>
        /// <returns></returns>
        /// <response code="200">Vraća traženog kupca</response>
        /// <response code="404">Vraća da kupac nije pronađen</response>


        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<KupacDto> GetKupacById(Guid id)
        {
            var kupac = _mapper.Map<KupacDto>(_kupacRepository.GetKupacById(id));
            //   List<JavnoNadmetanjeDto> javnaNadmetanja = _javnoNadmetanjeRepository.GetJavnaNadmetanja().ToList();
            //List<UplataDto> uplate = _uplataRepository.GetUplata().ToList();
            if (kupac == null)
            {
                return NoContent();
            }
            kupac.Adresa = _adresaService.GetAdresaByID(kupac.AdresaId).Result; ;

            
           

            List<OvlascenoLiceInfoDto> listaOL = new List<OvlascenoLiceInfoDto>();
            foreach (var ol in kupac.OvlascenaLica)
            {
                var lice = _mapper.Map<OvlascenoLiceInfoDto>(_ovlascenoLiceRepository.GetOvlascenoLiceById(ol));
                listaOL.Add(lice);

            }
            kupac.OvlascenaLicaObj = listaOL;

            List<JavnoNadmetanjeInfoDto> listaJn = new List<JavnoNadmetanjeInfoDto>();
            foreach (var jn in kupac.JavnaNadmetanja)
            {
                var javN = _javnoNadmetanjeService.GetJavnoNadmetanjeById(jn).Result;
                listaJn.Add(javN);

            }
            kupac.JavnaNadmetanjaOb = listaJn;

            var uplate1 = _uplataService.GetUplataByKupacID(kupac.KupacId).Result;
           
            kupac.Uplate = uplate1;


            if (kupac == null)
            {
                return NotFound();
            }
            return Ok(kupac);
        }


        /// <summary>
        /// Vrši brisanje jednog kupca na osnovu njegovog ID-ja.
        /// </summary>
        /// <param name="id">ID kupca</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Kupac uspješno obrisan</response>
        /// <response code="404">Nije pronađen kupac za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja kupca</response>


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public IActionResult DeleteKupac(Guid id)
        {

            try
            {
                var kupac = _kupacRepository.GetKupacById(id);

                if (kupac == null)
                {
                    return NotFound();
                }

                _kupacRepository.DeleteKupac(id);
                _kupacRepository.SaveChanges();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete error");
            }
        }
        /// <summary>
        /// Ažurira jednog kupca.
        /// </summary>
        /// <param name="noviKupac">Model kupca koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom kupcu.</returns>
        /// <response code="200">Vraća ažuriranog kupca</response>
        /// <response code="400">Kupac koie se ažurira nije pronađen</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja kupca</response>


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacUpdateDto> UpdateKupac([FromBody] KupacUpdateDto noviKupac)
        {
            try
            {

                var oldKupac = _kupacRepository.GetKupacById(noviKupac.KupacId);
                if (oldKupac == null)
                {
                    return NotFound(); //Ukoliko ne postoji vratiti status 404 (NotFound).
                }
                Kupac noviKupacEntity = _mapper.Map<Kupac>(noviKupac);

                _kupacRepository.UpdateKupac(oldKupac, noviKupacEntity);

                //_mapper.Map(noviKupacEntity, noviKupac); //Update objekta koji treba da sačuvamo u bazi                

                _kupacRepository.SaveChanges(); //Perzistiramo promene

                return Ok(_mapper.Map<KupacUpdateDto>(noviKupacEntity));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");
            }
        }
        /// <summary>
        /// Kreiranje novog kupca.
        /// </summary>
        /// <param name="kupac">Model kupca</param>
        /// <returns>Potvrdu o kreiranom kupcu.</returns>
        /// <remarks>
        /// Primjer zahtjeva za kreiranje novog kupca \
        /// POST /api/kupac \
        /// {     \
        ///     "PrioritetId":"FF3C45C2-BEE0-41F4-ADCF-3C323893D82B", \
        ///     "OstvarenaPovrsina": "190000", \
        ///     "ImaZabranu": false, \
        ///     "DatumPocetkaZabrane": null, \
        ///     "DatumPrestankaZabrane":null, \
        ///     "DuzinaTrajanjaZabraneUGod":0, \
        ///     "BrTelefona1":"066556789", \
        ///     "BrTelefona2":"0657899876567", \
        ///     "Email":"kupac23@gmail.com", \
        ///     "BrRacuna":"Ra-56854789", \
        ///     "AdresaId":"464F5478-3558-487A-AB81-7F5B10F5883A", \
        ///     "OvlascenaLica":"D915A418-7178-42AB-A25A-E9547568EEA3", \
        ///     "JavnaNadmetanja":"55311152-4708-4A42-A980-C74FB1BDEE5F", \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreiranog kupac</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja kupca</response>


        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacConfirmationDto> CreateKupac([FromBody] KupacCreationDto kupac)
        {
            try
            {
                Kupac kupactEntity = _mapper.Map<Kupac>(kupac);
                Kupac kup = _kupacRepository.CreateKupac(kupactEntity);
                _kupacRepository.SaveChanges(); //Perzistiramo promene



                string location = _linkGenerator.GetPathByAction("GetKupacs", "Kupac", new { KupacId = kup.KupacId });
                return Created(location, _mapper.Map<KupacConfirmationDto>(kup));


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Create error");
            }
        }

        /// <summary>
        /// Vraća listu kupaca za dato ovlašćeno lice.
        /// </summary>
        ///  /// <param name="ovlascenoLiceId">ID ovlaštenog lica</param>
        /// <returns></returns>
        /// <response code="200">Vraća tražene kupce</response>
        /// <response code="404">Vraća da kupaci nisu pronađeni</response>
        [HttpGet("ovlascenoLice/{ovlascenoLiceId}")]
        public ActionResult<List<KupacInfoDto>> GetKupacByOvlascenoLiceId(Guid ovlascenoLiceId)
        {
            var kupci = _kupacRepository.GetKupacByOvlascenoLiceId(ovlascenoLiceId);
            if(kupci.Count == 0 || kupci == null)
            {
                return NoContent();
            }

            List<KupacInfoDto> kupacDtos = new List<KupacInfoDto>();

            foreach (var kupac in kupci)
            {
                Kupac tempKupac = _kupacRepository.GetKupacById(kupac.KupacId);
                var tempKupacDto = _mapper.Map<KupacInfoDto>(tempKupac);

                kupacDtos.Add(tempKupacDto);

            }

            // var kupacInfo = _mapper.Map<List<KupacInfoDto>>(kupacDtos);
            return Ok(kupacDtos);
        }


        [HttpGet("vo/{kupacId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<KupacInfoDto> GetKupacByIdVO(Guid kupacId)
        {
            var kupac = _mapper.Map<KupacInfoDto>(_kupacRepository.GetKupacByIdVO(kupacId));


            if (kupac == null)
            {
                return NotFound();
            }
            return Ok(kupac);
        }

        /// <summary>
        /// Vraća opcije za rad sa kupcem
        /// </summary>
        [HttpOptions]
        public IActionResult GetKupacOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }

}
