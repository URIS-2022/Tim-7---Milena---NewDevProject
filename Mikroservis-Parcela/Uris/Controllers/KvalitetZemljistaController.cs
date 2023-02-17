using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uris.Context;
using Uris.DTO;
using Uris.Models;
using Uris.Repositories.KulturaRepository;
using Uris.Repositories.KvalitetZemljistaRepository;

namespace Uris.Controllers
{
    [Route("api/KvalitetZemljista")]
    [ApiController]
    public class KvalitetZemljistaController : ControllerBase
    {
        private readonly IKvalitetZemljistaRepository kvalitetZemljistaRepository;
        private readonly IMapper mapper;

        public KvalitetZemljistaController(IKvalitetZemljistaRepository kvalitetZemljistaRepository, IMapper mapper)
        {
            this.kvalitetZemljistaRepository = kvalitetZemljistaRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<KvalitetZemljistaDto>> GetAll()
        {
            return Ok(mapper.Map<List<KvalitetZemljistaDto>>(kvalitetZemljistaRepository.GetAll().ToList()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KvalitetZemljistaDto> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var kvalitetZemljista = kvalitetZemljistaRepository.GetById(id);

            if (kvalitetZemljista == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<KvalitetZemljistaDto>(kvalitetZemljista));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KvalitetZemljistaDto> Post([FromBody] KvalitetZemljistaDto kvalitetZemljistaDTO)
        {
            if (kvalitetZemljistaDTO == null)
            {
                return BadRequest(kvalitetZemljistaDTO);
            }
            if (kvalitetZemljistaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(kvalitetZemljistaRepository.Add(mapper.Map<KvalitetZemljista>(kvalitetZemljistaDTO)));
        }

        [HttpPut("{id:int}")]
        public ActionResult<KvalitetZemljistaDto> Update(int id, [FromBody] KvalitetZemljistaDto kvalitetZemljistaDTO)
        {
            if (kvalitetZemljistaDTO == null || id != kvalitetZemljistaDTO.Id)
            {
                return BadRequest();
            }

            var kvalitetZemljista = mapper.Map<KvalitetZemljista>(kvalitetZemljistaDTO);
            kvalitetZemljistaRepository.Update(kvalitetZemljista, kvalitetZemljista.Id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var kvalitetZemljista = kvalitetZemljistaRepository.GetById(id);

            if (kvalitetZemljista == null)
            {
                return NotFound();
            }

            kvalitetZemljistaRepository.Delete(id);
            return NoContent();
        }
    }
}
