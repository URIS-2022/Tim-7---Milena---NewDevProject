using AutoMapper;
using KomisijaURIS.Data1;
using KomisijaURIS.Entites;
using KomisijaURIS.Interfaces;
using KomisijaURIS.Models;
using KomisijaURIS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KomisijaURIS.Controllers
{
    [Route("api/Predsednik")]
    [ApiController]
    public class PredsednikController : ControllerBase
    {
        private readonly IPredsednikRepository predsednikRepository;
        private readonly IMapper mapper;

        public PredsednikController(IPredsednikRepository predsednikRepository, IMapper mapper)
        {
            this.predsednikRepository = predsednikRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraca sve predsednike komisija
        /// </summary>
        /// /// <param name="ImePredsednika"></param>
        /// <param name="PrezimePredsednika"></param>
        /// <param name="EmailPredsednika"></param>
        /// <returns></returns>

        [HttpGet]
        public ActionResult<IEnumerable<PredsednikDto>> GetAll()
        {
            return Ok(mapper.Map<List<PredsednikDto>>(predsednikRepository.GetAll().ToList()));
        }

        /// <summary>
        /// Vraca predsednika na osnovu ID
        /// </summary>
        /// <param name="PredsednikId"></param>
        /// <returns></returns>

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PredsednikDto> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var predsednik = predsednikRepository.GetById(id);

            if (predsednik == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<PredsednikDto>(predsednik));
        }

        /// <summary>
        /// Dodaje novog predsednika komisije 
        /// </summary>
        /// <param name="Predsednik"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PredsednikDto> CreatePredsednik([FromBody]PredsednikDto predsednikDto)
        {
            
            if (predsednikDto == null)
            {
                return BadRequest(predsednikDto);
            }
            if (predsednikDto.PredsednikId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
            var predsednik = mapper.Map<Predsednik>(predsednikDto);
            predsednikRepository.Add(predsednik);

            return Ok(predsednik);
            
        }

        /// <summary>
        /// Vrsi izmenu nad predsednikom komisije koji se prosledio u body-u
        /// </summary>
        /// <param name="Predsednik"></param>
        /// <returns>Potvrdu o modifikovanom predsedniku komisije</returns>
        /// <response code="204">Vraca azuriranog predsednika komisije</response>
        /// <response code="400">Predsednik komisije koji se azurira nije pronadjen</response>


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PredsednikDto> UpdatePredsednik(int id, [FromBody] PredsednikDto predsednikDto)
        {
            if (predsednikDto == null || id != predsednikDto.PredsednikId)
            {
                return BadRequest();
            }
            
            var predsednik = mapper.Map<Predsednik>(predsednikDto);
            predsednikRepository.Update(predsednik, predsednik.PredsednikId);

            return NoContent();
        }

        /// <summary>
        /// Brise predsednika komisije sa prosledjenim id-em iz liste
        /// </summary>
        /// <param name="PredsednikId"></param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Predsednik uspesno obrisan</response>
        /// <response code="404">Nije pronadjen predsednik za brisanje</response>
        /// <response code="400">Poslat neispravan zahtev</response>

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePredsednik(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var predsednik = predsednikRepository.GetById(id);

            if (predsednik == null)
            {
                return NotFound();
            }
            predsednikRepository.Delete(id);
            return NoContent();
        }
    }
}
