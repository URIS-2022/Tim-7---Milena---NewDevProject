using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mikroservis_Uplata.DTO;
using Mikroservis_Uplata.Models;
using Mikroservis_Uplata.Repositories.KursRepository;

namespace Mikroservis_Uplata.Controllers
{
    [Route("api/Kurs")]
    [ApiController]
    public class KursController : ControllerBase
    {
        private readonly IKursRepository kursRepository;
        private readonly IMapper mapper;

        public KursController(IKursRepository kursRepository, IMapper mapper)
        {
            this.kursRepository = kursRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<KursDTO>> GetAll()
        {
            return Ok(mapper.Map<List<KursDTO>>(kursRepository.GetAll().ToList()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KursDTO> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var kurs = kursRepository.GetById(id);

            if (kurs == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<KursDTO>(kurs));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KursDTO> Post([FromBody] KursDTO kursDTO)
        {
            if (kursDTO == null)
            {
                return BadRequest(kursDTO);
            }
            if (kursDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var kurs = mapper.Map<Kurs>(kursDTO);
            kursRepository.Add(kurs);

            return Ok(kurs);
        }

        [HttpPut("{id:int}")]
        public ActionResult<KursDTO> Update(int id, [FromBody] KursDTO kursDTO)
        {
            if (kursDTO == null || id != kursDTO.Id)
            {
                return BadRequest();
            }

            var kurs = mapper.Map<Kurs>(kursDTO);
            kursRepository.Update(kurs, kurs.Id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var kurs = kursRepository.GetById(id);

            if (kurs == null)
            {
                return NotFound();
            }

            kursRepository.Delete(id);
            return NoContent();
        }
    }
}
