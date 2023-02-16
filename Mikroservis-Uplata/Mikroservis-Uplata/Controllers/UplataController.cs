using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mikroservis_Uplata.DTO;
using Mikroservis_Uplata.Models;
using Mikroservis_Uplata.Repositories.KursRepository;
using Mikroservis_Uplata.Repositories.UplataRepository;
using Mikroservis_Uplata.ServiceCalls;

namespace Mikroservis_Uplata.Controllers
{
    [Route("api/Uplata")]
    [ApiController]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository uplataRepository;
        private readonly IMapper mapper;
        private readonly IKursRepository kursRepository;

        private readonly IKupacService kupacService;
        private readonly IJavnoNadmetanjeService javnoNadmetanjeService;

        public UplataController(IUplataRepository uplataRepository, IKursRepository kursRepository, IMapper mapper, 
            IJavnoNadmetanjeService javnoNadmetanjeService, IKupacService kupacService)
        {
            this.uplataRepository = uplataRepository;
            this.mapper = mapper;
            this.kursRepository = kursRepository;
            this.javnoNadmetanjeService = javnoNadmetanjeService;
            this.kupacService = kupacService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UplataDTO>> GetAll()
        {
            List<UplataDTO> uplate = mapper.Map<List<UplataDTO>>(uplataRepository.GetAll().ToList());
            foreach (var obj in uplate)
            {
                obj.KupacDTO = kupacService.GetKupacById(obj.KupacId).Result;
                obj.JavnoNadmetanjeDTO = javnoNadmetanjeService.GetJavnoNadmetanjeById(obj.JavnoNadmetanjeId).Result;
            }
            return Ok(uplate);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UplataDTO> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var uplata = mapper.Map<UplataDTO>(uplataRepository.GetById(id));

            if (uplata == null)
            {
                return NotFound();
            }

            uplata.JavnoNadmetanjeDTO = javnoNadmetanjeService.GetJavnoNadmetanjeById(uplata.JavnoNadmetanjeId).Result;
            uplata.KupacDTO = kupacService.GetKupacById(uplata.KupacId).Result;

            return Ok(uplata);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UplataDTO> Post([FromBody] UplataCreationDTO uplataDTO) 
        {
            if (uplataDTO == null)
            {
                return BadRequest(uplataDTO);
            }
            if (uplataDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var kurs = kursRepository.GetById(uplataDTO.KursID);

            if (kurs == null)
            {
                return BadRequest("Ne postoji kurs sa prosleđenim ID-jem");
            }

            return Ok(uplataRepository.Add(mapper.Map<Uplata>(uplataDTO)));
        }

        [HttpPut("{id:int}")]
        public ActionResult<UplataDTO> Update(int id, [FromBody] UplataDTO uplataDTO)
        {
            if (uplataDTO == null || id != uplataDTO.Id)
            {
                return BadRequest();
            }

            var kurs = kursRepository.GetById(uplataDTO.KursID);

            if (kurs == null)
            {
                return BadRequest("Ne postoji kurs sa prosleđenim ID-jem");
            }

            var uplata = mapper.Map<Uplata>(uplataDTO);
            uplataRepository.Update(uplata, uplata.Id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var uplata = uplataRepository.GetById(id);

            if (uplata == null)
            {
                return NotFound();
            }

            uplataRepository.Delete(id);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("vo/{parcelaId}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<UplataInfoDTO> GetUplateZaDrugeServiseByID(int uplataId)
        {
            var uplata = uplataRepository.GetUplataByIdVO(uplataId);
            if (uplata == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UplataInfoDTO>(uplata));

        }

        [HttpGet("{kupacId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<UplataInfoDTO>> GetUplateZaDrugeServiseByKupacId(Guid kupacId)
        {
            var uplate = uplataRepository.GetUplateByKupacIdVO(kupacId);

            if (uplate.Count() == 0)
            {
                return NotFound("Nije pronađena nijedna uplata za prosleđenog kupca!");
            }

            return Ok(mapper.Map<List<UplataInfoDTO>>(uplate));
        }
    }
}
