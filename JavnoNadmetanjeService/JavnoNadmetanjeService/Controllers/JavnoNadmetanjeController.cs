using AutoMapper;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.Models;
using JavnoNadmetanjeService.Repository;
using JavnoNadmetanjeService.ServiceCalls;
using Microsoft.AspNetCore.Mvc;


namespace JavnoNadmetanjeService.Controllers
{
    [ApiController]
    [Route("api/javnoNadmetanje")]
    public class JavnoNadmetanjeController:ControllerBase
    {
        private readonly IJavnoNadmetanjeRepository javnoNadmetanjeRepository;
        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;
        private readonly IAdresaService adresaService;
        private readonly IKupacService kupacService;
        private readonly IOvlascenoLiceService ovlascenoLiceService;
        private readonly IParcelaService parcelaService;


        public JavnoNadmetanjeController(IJavnoNadmetanjeRepository javnoNadmetanjeRepository, IMapper mapper, LinkGenerator linkGenerator,IAdresaService adresaService, IKupacService kupacService, IOvlascenoLiceService ovlascenoLiceService, IParcelaService parcelaService)
        {
            this.javnoNadmetanjeRepository = javnoNadmetanjeRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
            this.adresaService = adresaService;
            this.kupacService = kupacService;
            this.ovlascenoLiceService = ovlascenoLiceService;
            this.parcelaService = parcelaService;
        }

        /// <summary>
        /// Vraca sva javna nadmetanja
        /// </summary>
        /// <param name="status">Status javnog nadmetanja (npr. Prvi krug)</param>
        /// <param name="tip">Tip javnog nadmetanja (npr. Javna licitacija)</param>
        /// <returns> Lista svih javnih nadmetanja </returns>
        /// <response code="200">Vraca listu svih javnih nadmetanja</response>
        /// <response code="404">Ne postoji nijedno javno nadmetanje</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        [HttpHead]

        public ActionResult<List<JavnoNadmetanjeDto>> GetJavnaNadmetanja([FromQuery] string? status=null,string? tip=null)
        {
            List<JavnoNadmetanjeDto> javnaNadmetanja = mapper.Map<List<JavnoNadmetanjeDto >>(javnoNadmetanjeRepository.GetJavnaNadmetanja(status,tip));
            if (javnaNadmetanja == null || javnaNadmetanja.Count == 0)
            {
                return NoContent();
            }
            foreach (var jn in javnaNadmetanja)
            {
                AdresaDto adresa = adresaService.GetAdresaById(jn.AdresaID).Result;  
                jn.Adresa = adresa;
                KupacInfoDto najboljiPonudjac = kupacService.GetKupacById(jn.KupacID).Result;
                jn.NajboljiPonudjac = najboljiPonudjac;
                List<KupacInfoDto> kupci = new List<KupacInfoDto>();
                List<OvlascenoLiceInfoDto> licitanti = new List<OvlascenoLiceInfoDto>();
                List<ParcelaInfoDto> parcele = new List<ParcelaInfoDto>();
                foreach (var kupacID in jn.PrijavljeniKupciID)
                {
                    KupacInfoDto prijavljeniKupac = kupacService.GetKupacById(kupacID).Result;
                    kupci.Add(prijavljeniKupac);
                }
                foreach(var ovlascenoLiceID in jn.LicitantiID)
                {
                    OvlascenoLiceInfoDto ovlascenoLice = ovlascenoLiceService.GetOvlascenoLiceById(ovlascenoLiceID).Result;
                    licitanti.Add(ovlascenoLice);
                }
                foreach (var parcelaID in jn.ParceleID)
                {
                    ParcelaInfoDto parcela = parcelaService.GetParcelaById(parcelaID).Result;
                    parcele.Add(parcela);
                }
                jn.PrijavljeniKupci = kupci;
                jn.Licitanti = licitanti;
                jn.Parcele = parcele;
            }
            return Ok(javnaNadmetanja);
        }

        /// <summary>
        /// Vraca jedno javno nadmetanje na osnovu ID-ja javnog nadmetanja.
        /// </summary>
        /// <param name="javnoNadmetanjeID">ID javnog nadmetanja</param>
        /// <returns>Odgovarajuće javno nadmetanje</returns>
        /// <response code="200">Vraća traženo javno nadmetanje</response>
        /// <response code="404">Nije pronadjeno traženo javno nadmetanje</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{javnoNadmetanjeID}")]
        public ActionResult<JavnoNadmetanjeDto> GetJavnoNadmetanjeByID(Guid javnoNadmetanjeID)
        {
            var javnoNadmetanje = mapper.Map<JavnoNadmetanjeDto>(javnoNadmetanjeRepository.GetJavnoNadmetanje(javnoNadmetanjeID));
            if (javnoNadmetanje == null)
            {
                return NotFound();
            }
            AdresaDto adresa = adresaService.GetAdresaById(javnoNadmetanje.AdresaID).Result;
            javnoNadmetanje.Adresa = adresa;
            KupacInfoDto najboljiPonudjac = kupacService.GetKupacById(javnoNadmetanje.KupacID).Result;
            javnoNadmetanje.NajboljiPonudjac = najboljiPonudjac;
            List<KupacInfoDto> kupci = new List<KupacInfoDto>();
            List<OvlascenoLiceInfoDto> licitanti = new List<OvlascenoLiceInfoDto>();
            List<ParcelaInfoDto> parcele = new List<ParcelaInfoDto>();
            foreach (var kupacID in javnoNadmetanje.PrijavljeniKupciID)
            {
                KupacInfoDto prijavljeniKupac = kupacService.GetKupacById(kupacID).Result;
                kupci.Add(prijavljeniKupac);
            }
            foreach (var ovlascenoLiceID in javnoNadmetanje.LicitantiID)
            {
                OvlascenoLiceInfoDto ovlascenoLice = ovlascenoLiceService.GetOvlascenoLiceById(ovlascenoLiceID).Result;
                licitanti.Add(ovlascenoLice);
            }
            foreach (var parcelaID in javnoNadmetanje.ParceleID)
            {
                ParcelaInfoDto parcela = parcelaService.GetParcelaById(parcelaID).Result;
                parcele.Add(parcela);
            }
            javnoNadmetanje.PrijavljeniKupci = kupci;
            javnoNadmetanje.Licitanti = licitanti;
            javnoNadmetanje.Parcele = parcele;
            return Ok(javnoNadmetanje);

        }
        /// <summary>
        /// Vraca jedno javno nadmetanje na osnovu ID-ja javnog nadmetanja za druge mikroservise.
        /// </summary>
        /// <param name="javnoNadmetanjeID">ID javnog nadmetanja</param>
        /// <returns>Odgovarajuće informacije o javnom nadmetanju prilagodjene potrebama drugih mikroservisa</returns>
        ///<response code="200">Vraća traženo javno nadmetanje</response>
        ///<response code="404">Nije pronadjeno traženo javno nadmetanje</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("vo/{javnoNadmetanjeID}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<JavnoNadmetanjeInfoDto> GetJavnoNadmetanjeZaDrugeServiseByID(Guid javnoNadmetanjeID)
        {
            var javnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeByIdVO(javnoNadmetanjeID);
            if (javnoNadmetanje == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<JavnoNadmetanjeInfoDto>(javnoNadmetanje));

        }

        /// <summary>
        /// Kreira novo javno nadmetanje.
        /// </summary>
        /// <param name="javnoNadmetanje">Model javnog nadmetanja</param>
        /// <remarks>
        /// Primer zahteva za kreiranje novog javnog nadmetanja \
        /// POST /api/javnoNadmetanje \
        /// { \
        ///"datum": "2023-02-16T16:41:41.220Z", \
        ///"vremePocetka": "11:00", \
        ///"vremeKraja": "14:000", \
        ///"pocetnaCenaPoHektaru": 500, \
        ///"izuzeto": true, \
        ///"tipJavnogNadmetanjaID": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        ///"statusJavnogNadmetanjaID": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        ///"izlicitiranaCena": 1000, \
        ///"periodZakupa":4, \
        ///"brojUcesnika": 2, \
        ///"visinaDopuneDepozita": 200, \
        ///"krug": 2, \
        ///"licitantiID": [
        ///    "3fa85f64-5717-4562-b3fc-2c963f66afa6" \
        ///], \
        ///"prijavljeniKupciID": [ \
        ///    "3fa85f64-5717-4562-b3fc-2c963f66afa6" \
        ///], \
        ///"parcela": [ \
        /// 1 \
        ///], \
        ///"adresaID": "3fa85f64-5717-4562-b3fc-2c963f66afa6", \
        ///"kupacID": "3fa85f64-5717-4562-b3fc-2c963f66afa6" \
        ///} 
        ///</remarks>
        /// <response code="201">Vraća kreirano javno nadmetanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja javnog nadmetanja</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoNadmetanjeConfirmationDto> CreateJavnoNadmetanje([FromBody] JavnoNadmetanjeCreationDto javnoNadmetanje)
        {
            try
            {
                var nadmetanje = mapper.Map<JavnoNadmetanje>(javnoNadmetanje);
                JavnoNadmetanje confirmation = javnoNadmetanjeRepository.CreateJavnoNadmetanje(nadmetanje);
                string? location = linkGenerator.GetPathByAction("GetJavnaNadmetanja", "JavnoNadmetanje", new { JavnoNadmetanjeID = nadmetanje.JavnoNadmetanjeID });
                return Created(location, mapper.Map<JavnoNadmetanjeConfirmationDto>(confirmation));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja javnog nadmetanja!");
            }
        }
        /// <summary>
        /// Ažurira jedno javno nadmetanje
        /// </summary>
        /// <param name="javnoNadmetanje">Model javnog nadmetanja koje se ažurira</param>
        /// <returns>Potvrda o modfikovanom javnom nadmetanju</returns>
        /// <response code="200">Vraća kreirano javno nadmetanje</response>
        /// <response code="400">Željeno javno nadmetanje koje se želi ažurirati nije pronađeno</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja javnog nadmetanja</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoNadmetanjeUpdateDto> UpdateJavnoNadmetanje([FromBody] JavnoNadmetanjeUpdateDto javnoNadmetanje)
        {

            try
            {
                JavnoNadmetanje staroJavnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanje(javnoNadmetanje.JavnoNadmetanjeID);
                if (staroJavnoNadmetanje == null)
                {
                    return NotFound();
                }
                JavnoNadmetanje novoJavnoNadmetanje = mapper.Map<JavnoNadmetanje>(javnoNadmetanje);
                javnoNadmetanjeRepository.UpdateJavnoNadmetanje(staroJavnoNadmetanje, novoJavnoNadmetanje);
                return Ok(mapper.Map<JavnoNadmetanjeUpdateDto>(novoJavnoNadmetanje));

            }
            catch (Exception)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom ažuriranja javnog nadmetanja!");
            }
        }
        /// <summary>
        /// Vrši brisanje jednog javnog nadmetanja na osnovu ID-ja javnog nadmetanja.
        /// </summary>
        /// <param name="javnoNadmetanjeID">ID javnog nadmetanja</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Javnog nadmetanje je uspešno obrisano</response>
        /// <response code="404">Nije pronađeno javno nadmetanje za brisanje</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja javnog nadmetanja</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{javnoNadmetanjeID}")]
        public IActionResult DeleteJavnoNadmetanje(Guid javnoNadmetanjeID)
        {
            try
            {
                var javnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanje(javnoNadmetanjeID);

                if (javnoNadmetanje == null)
                {
                    return NotFound();
                }

                javnoNadmetanjeRepository.DeleteJavnoNadmetanje(javnoNadmetanjeID);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom brisanja javnog nadmetanja");
            }
        }
        /// <summary>
        /// Vraća opcije za rad sa javnim nadmetanjem
        /// </summary>
        [HttpOptions]
        public IActionResult GetJavnoNadmetanjeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}
