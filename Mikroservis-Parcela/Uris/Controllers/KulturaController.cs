using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uris.DTO;
using Uris.Models;
using Uris.Repositories.KulturaRepository;

namespace Uris.Controllers
{
    [Route("api/Kultura")]
    [ApiController]
    public class KulturaController : ControllerBase
    {
        private readonly IKulturaRepository kulturaRepository;
        private readonly IMapper mapper;

        public KulturaController(IKulturaRepository kulturaRepository, IMapper mapper)
        {
            this.kulturaRepository = kulturaRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<KulturaDto>> GetAll()
        {
            return Ok(mapper.Map<List<KulturaDto>>(kulturaRepository.GetAll().ToList()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KulturaDto> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var kultura = kulturaRepository.GetById(id);

            if (kultura == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<KulturaDto>(kultura));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KulturaDto> Post([FromBody] KulturaDto kulturaDTO)
        {
            if (kulturaDTO == null)
            {
                return BadRequest(kulturaDTO);
            }
            if (kulturaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var kultura = mapper.Map<Kultura>(kulturaDTO);
            kulturaRepository.Add(kultura);

            return Ok(kultura);
        }

        [HttpPut("{id:int}")]
        public ActionResult<KulturaDto> Update(int id, [FromBody] KulturaDto kulturaDTO)
        {
            if (kulturaDTO == null || id != kulturaDTO.Id)
            {
                return BadRequest();
            }

            var kultura = mapper.Map<Kultura>(kulturaDTO);
            kulturaRepository.Update(kultura, kultura.Id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var kultura = kulturaRepository.GetById(id);

            if (kultura == null)
            {
                return NotFound();
            }
            kulturaRepository.Delete(id);
            return NoContent();
        }


    }
}
