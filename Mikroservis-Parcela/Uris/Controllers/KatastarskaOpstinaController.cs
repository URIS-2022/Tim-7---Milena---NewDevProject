using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uris.DTO;
using Uris.Models;
using Uris.Repositories.KatastarskaOpstinaRepository;
using Uris.Repositories.KulturaRepository;

namespace Uris.Controllers
{
    [Route("api/KatastarskaOpstina")]
    [ApiController]
    public class KatastarskaOpstinaController : ControllerBase
    {
        private readonly IKatastarskaOpstinaRepository katastarskaOpstinaRepository;
        private readonly IMapper mapper;

        public KatastarskaOpstinaController(IKatastarskaOpstinaRepository katastarskaOpstinaRepository, IMapper mapper)
        {
            this.katastarskaOpstinaRepository = katastarskaOpstinaRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<KatastarskaOpstinaDto>> GetAll()
        {
            return Ok(mapper.Map<List<KatastarskaOpstinaDto>>(katastarskaOpstinaRepository.GetAll().ToList()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KatastarskaOpstinaDto> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var katastarskaOpstina = katastarskaOpstinaRepository.GetById(id);

            if (katastarskaOpstina == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<KatastarskaOpstinaDto>(katastarskaOpstina));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KatastarskaOpstinaDto> Post([FromBody] KatastarskaOpstinaDto katastarskaOpstinaDTO)
        {
            if (katastarskaOpstinaDTO == null)
            {
                return BadRequest(katastarskaOpstinaDTO);
            }
            if (katastarskaOpstinaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var katastarskaOpstina = mapper.Map<KatastarskaOpstina>(katastarskaOpstinaDTO);
            katastarskaOpstinaRepository.Add(katastarskaOpstina);

            return Ok(katastarskaOpstina);
        }

        [HttpPut("{id:int}")]
        public ActionResult<KatastarskaOpstinaDto> Update(int id, [FromBody] KatastarskaOpstinaDto katastarskaOpstinaDTO)
        {
            if (katastarskaOpstinaDTO == null || id != katastarskaOpstinaDTO.Id)
            {
                return BadRequest();
            }

            var katastarskaOpstina = mapper.Map<KatastarskaOpstina>(katastarskaOpstinaDTO);
            katastarskaOpstinaRepository.Update(katastarskaOpstina, katastarskaOpstina.Id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var katastarskaOpstina = katastarskaOpstinaRepository.GetById(id);

            if (katastarskaOpstina == null)
            {
                return NotFound();
            }

            katastarskaOpstinaRepository.Delete(id);
            return NoContent();
        }

    }
}
