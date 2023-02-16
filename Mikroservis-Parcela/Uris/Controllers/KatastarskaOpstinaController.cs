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
        public ActionResult<IEnumerable<KatastarskaOpstinaDTO>> GetAll()
        {
            return Ok(mapper.Map<List<KatastarskaOpstinaDTO>>(katastarskaOpstinaRepository.GetAll().ToList()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KatastarskaOpstinaDTO> GetById(int id)
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

            return Ok(mapper.Map<KatastarskaOpstinaDTO>(katastarskaOpstina));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KatastarskaOpstinaDTO> Post([FromBody] KatastarskaOpstinaDTO katastarskaOpstinaDTO)
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
        public ActionResult<KatastarskaOpstinaDTO> Update(int id, [FromBody] KatastarskaOpstinaDTO katastarskaOpstinaDTO)
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
