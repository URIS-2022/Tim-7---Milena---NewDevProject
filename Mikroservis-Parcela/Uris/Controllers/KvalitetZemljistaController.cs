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
        public ActionResult<IEnumerable<KvalitetZemljistaDTO>> GetAll()
        {
            return Ok(mapper.Map<List<KvalitetZemljistaDTO>>(kvalitetZemljistaRepository.GetAll().ToList()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KvalitetZemljistaDTO> GetById(int id)
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

            return Ok(mapper.Map<KvalitetZemljistaDTO>(kvalitetZemljista));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KvalitetZemljistaDTO> Post([FromBody] KvalitetZemljistaDTO kvalitetZemljistaDTO)
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
        public ActionResult<KvalitetZemljistaDTO> Update(int id, [FromBody] KvalitetZemljistaDTO kvalitetZemljistaDTO)
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
