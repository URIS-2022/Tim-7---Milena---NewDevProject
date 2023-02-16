using AutoMapper;
using KomisijaURIS.Data1;
using KomisijaURIS.Entites;
using KomisijaURIS.Interfaces;
using KomisijaURIS.Models;
using KomisijaURIS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KomisijaURIS.Controllers
{
    [Route("api/Komisija")]
    [ApiController]
    public class KomisijaController : ControllerBase
    {
        private readonly IKomisijaRepository komisijaRepository;
        private readonly IMapper mapper;
        private readonly IPredsednikRepository predsednikRepository;
        private readonly IClanKomisijeRepository clanKomisijeRepository;

        public KomisijaController(IKomisijaRepository komisijaRepository , IMapper mapper, IPredsednikRepository predsednikRepository, IClanKomisijeRepository clanKomisijeRepository)
        {
            this.komisijaRepository = komisijaRepository;
            this.mapper = mapper;
            this.predsednikRepository = predsednikRepository;
            this.clanKomisijeRepository = clanKomisijeRepository;
        }

        /// <summary>
        /// Vraca sve komisije iz liste
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult<IEnumerable<KomisijaGetDto>> GetAll()
        {
            var komisijaDb = komisijaRepository.GetAll(includeProperties: "Clan,Predsednik");
            List<KomisijaGetDto> komisija = new List<KomisijaGetDto>();

            foreach (var k in komisijaDb)
            {
                komisija.Add(new KomisijaGetDto(k));
            }
            return Ok(komisija);
        }

        /// <summary>
        /// Vraca komisiju na osnovu id-a
        /// </summary>
        /// <param name="komisijaId"></param>
        /// <returns></returns>

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KomisijaGetDto> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var komisijaDb = komisijaRepository.GetById(x => x.KomisijaId == id,includeProperties: "Clan,Predsednik");

            if (komisijaDb == null)
            {
                return NotFound();
            }
            
            return Ok(new KomisijaGetDto(komisijaDb));
        }

        /// <summary>
        /// Dodaje novu komisiju u listu
        /// </summary>
        /// <param name="Komisija"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KomisijaDto> CreateKomisija([FromBody] KomisijaDto komisijaDto)
        {

            if (komisijaDto == null)
            {
                return BadRequest(komisijaDto);
            }
            if (komisijaDto.KomisijaId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            
            Komisija komisija = new Komisija();
           

            var predsednik = predsednikRepository.GetById(komisijaDto.PredsednikId);
            
            komisija.Predsednik = predsednik;
            List<ClanKomisije> clanoviKomisije = new List<ClanKomisije>();
            foreach (var x in komisijaDto.ClanId)
                clanoviKomisije.Add(clanKomisijeRepository.GetById(x));
            komisija.Clan = clanoviKomisije;
            komisijaRepository.Add(komisija);

            return Ok(komisija);

        }

        /// <summary>
        /// Vrsi izmenu nad komisijom koji se prosledio u body-u
        /// </summary>
        /// <param name="Komisija"></param>
        /// <returns>Potvrdu o modifikovanoj komisiji</returns>
        /// <response code="204">Vraca azuriranu komisiju</response>
        /// <response code="400">Komisija koja se azurira nije pronadjena</response>

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<KomisijaDto> UpdateKomisija(int id, [FromBody] KomisijaDto komisijaDto)
        {
            if (komisijaDto == null)
            {
                return BadRequest(komisijaDto);
            }
            if (komisijaDto.KomisijaId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            
            var komisija = komisijaRepository.GetById(id);

            List<ClanKomisije> clanoviKomisije = new List<ClanKomisije>();
            foreach (var x in komisijaDto.ClanId)
                clanoviKomisije.Add(clanKomisijeRepository.GetById(x));
            komisija.Clan = clanoviKomisije;

            var predsednik = predsednikRepository.GetById(komisijaDto.PredsednikId);
            
            komisija.Predsednik = predsednik;

            komisijaRepository.Update(komisija, id);



            return Ok(komisija);
        }

        /// <summary>
        /// Brise komisije sa prosledjenim id-em iz liste
        /// </summary>
        /// <param name="KomisijaId"></param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Komisija uspesno obrisana</response>
        /// <response code="404">Nije pronadjena komisija za brisanje</response>
        /// <response code="400">Poslat neispravan zahtev</response>

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteKomisija(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var komisija = komisijaRepository.GetById(x => x.KomisijaId == id, includeProperties: "Clan");

            if (komisija == null)
            {
                return NotFound();
            }
            komisijaRepository.Delete(id);
            return NoContent();
        }


    }
}
