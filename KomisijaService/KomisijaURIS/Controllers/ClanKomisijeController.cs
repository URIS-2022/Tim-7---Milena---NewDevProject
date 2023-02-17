using AutoMapper;
using KomisijaURIS.Entites;
using KomisijaURIS.Interfaces;
using KomisijaURIS.Models;
using Microsoft.AspNetCore.Mvc;

namespace KomisijaURIS.Controllers
{
    [Route("api/ClanKomisije")]
    [ApiController]
    public class ClanKomisijeController : ControllerBase
    {
        private readonly IClanKomisijeRepository clanKomisijeRepository;
        private readonly IMapper mapper;

        public ClanKomisijeController(IClanKomisijeRepository clanKomisijeRepository, IMapper mapper)
        {
            this.clanKomisijeRepository = clanKomisijeRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca sve clanove komisije
        /// </summary>
        /// <param name="ImeClana"></param>
        /// <param name="PrezimeClana"></param>
        /// <param name="EmailClana"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult<IEnumerable<ClanKomisijeDto>> GetAll()
        {
            return Ok(mapper.Map<List<ClanKomisijeDto>>(clanKomisijeRepository.GetAll().ToList()));
        }

        /// <summary>
        /// Vraca clana komisije na osnovu ID-a
        /// </summary>
        /// <param name="ClanId"></param>
        /// <returns></returns>

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClanKomisijeDto> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var clanKomisije = clanKomisijeRepository.GetById(id);

            if (clanKomisije == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ClanKomisijeDto>(clanKomisije));
        }

        /// <summary>
        /// Dodaje novog clana komisije u listu
        /// </summary>
        /// <param name="ClanKomisije"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClanKomisijeDto> CreateClanKomisije([FromBody] ClanKomisijeDto clanKomisijeDto)
        {

            if (clanKomisijeDto == null)
            {
                return BadRequest(clanKomisijeDto);
            }
            if (clanKomisijeDto.ClanId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var clanKomisije = mapper.Map<ClanKomisije>(clanKomisijeDto);
            clanKomisijeRepository.Add(clanKomisije);

            return Ok(clanKomisije);

        }

        /// <summary>
        /// Vrsi izmenu nad clanom komisije koji se prosledio u body-u
        /// </summary>
        /// <param name="ClanKomisije"></param>
        /// <returns>Potvrdu o modifikovanom clanu komisije</returns>
        /// <response code="204">Vraca azuriranog clana komisije</response>
        /// <response code="400">Clan komisije koji se azurira nije pronadjen</response>

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ClanKomisijeDto> UpdateClanKomisije(int id, [FromBody] ClanKomisijeDto clanKomisijeDto)
        {
            if (clanKomisijeDto == null || id != clanKomisijeDto.ClanId)
            {
                return BadRequest();
            }
            
            var clanKomisije = mapper.Map<ClanKomisije>(clanKomisijeDto);
            clanKomisijeRepository.Update(clanKomisije, clanKomisije.ClanId);

            return Ok(clanKomisije);
        }

        /// <summary>
        /// Brise clana komisije sa prosledjenim id-em iz liste
        /// </summary>
        /// <param name="ClanId"></param>
        /// <response code="204">Clan komisije uspesno obrisan</response>
        /// <response code="404">Nije pronadjen clan komisije za brisanje</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteClanKomisije(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var clanKomisije = clanKomisijeRepository.GetById(id);

            if (clanKomisije == null)
            {
                return NotFound();
            }
            clanKomisijeRepository.Delete(id);
            return Ok("Uspesno obrisan clan komisije");
        }

    }
}
