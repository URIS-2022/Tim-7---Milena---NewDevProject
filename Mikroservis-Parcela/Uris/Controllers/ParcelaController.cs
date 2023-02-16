using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uris.DTO;
using Uris.Models;
using Uris.Repositories.KatastarskaOpstinaRepository;
using Uris.Repositories.KulturaRepository;
using Uris.Repositories.KvalitetZemljistaRepository;
using Uris.Repositories.ParcelaRepository;
using Uris.ServiceCalls;

namespace Uris.Controllers
{
    [Route("api/Parcela")]
    [ApiController]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaRepository parcelaRepository;
        private readonly IMapper mapper;
        private readonly IKulturaRepository kulturaRepository;
        private readonly IKvalitetZemljistaRepository kvalitetZemljistaRepository;
        private readonly IKatastarskaOpstinaRepository katastarskaOpstinaRepository;
        private readonly IKupacService kupacService;


        public ParcelaController(IParcelaRepository parcelaRepository, IKulturaRepository kulturaRepository, IKvalitetZemljistaRepository kvalitetZemljistaRepository, 
            IKatastarskaOpstinaRepository katastarskaOpstinaRepository, IMapper mapper, IKupacService kupacService)
        {
            this.parcelaRepository = parcelaRepository;
            this.mapper = mapper;
            this.kvalitetZemljistaRepository = kvalitetZemljistaRepository;
            this.kulturaRepository = kulturaRepository;
            this.katastarskaOpstinaRepository = katastarskaOpstinaRepository;
            this.kupacService = kupacService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ParcelaDTO>> GetAll()
        {
            var parcele = mapper.Map<List<ParcelaDTO>>(parcelaRepository.GetAll().ToList());

            foreach(var obj in parcele)
            {
                obj.KupacDTO = kupacService.GetKupacById(obj.KupacId).Result;
            }


            return Ok(parcele);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ParcelaDTO> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var parcela = mapper.Map<ParcelaDTO>(parcelaRepository.GetById(id));

            if (parcela == null)
            {
                return NotFound();
            }

            parcela.KupacDTO = kupacService.GetKupacById(parcela.KupacId).Result;

            return Ok(parcela);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ParcelaDTO> Post([FromBody] ParcelaCreationDTO parcelaDTO)
        {
            if (parcelaDTO == null)
            {
                return BadRequest(parcelaDTO);
            }

            if (parcelaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            var kvalitetZemljista = kvalitetZemljistaRepository.GetById(parcelaDTO.KvalitetZemljistaID);

            if (kvalitetZemljista == null)
            {
                return BadRequest("Ne postoji kvalitet zemljišta sa prosleđenim ID-jem");
            }

            var kultura = kulturaRepository.GetById(parcelaDTO.KulturaID);

            if (kultura == null)
            {
                return BadRequest("Ne postoji kultura sa prosleđenim ID-jem");
            }

            var katastarskaOpstina = katastarskaOpstinaRepository.GetById(parcelaDTO.KatastarskaOpstinaID);

            if (katastarskaOpstina == null)
            {
                return BadRequest("Ne postoji katastarska opština sa prosleđenim ID-jem");
            }

            var kupac = kupacService.GetKupacById(parcelaDTO.KupacId);

            if (kupac == null)
            {
                return BadRequest("Ne postoji kupac sa prosleđenim ID-jem");
            }

            return Ok(parcelaRepository.Add(mapper.Map<Parcela>(parcelaDTO)));
        }

        [HttpPut("{id:int}")]
        public ActionResult<ParcelaDTO> Update(int id, [FromBody] ParcelaDTO parcelaDTO)
        {
            if (parcelaDTO == null || id != parcelaDTO.Id)
            {
                return BadRequest();
            }

            var kvalitetZemljista = kvalitetZemljistaRepository.GetById(parcelaDTO.KvalitetZemljistaID);

            if (kvalitetZemljista == null)
            {
                return BadRequest("Ne postoji kvalitet zemljišta sa prosleđenim ID-jem");
            }

            var kultura = kulturaRepository.GetById(parcelaDTO.KulturaID);

            if (kultura == null)
            {
                return BadRequest("Ne postoji kultura sa prosleđenim ID-jem");
            }

            var katastarskaOpstina = katastarskaOpstinaRepository.GetById(parcelaDTO.KatastarskaOpstinaID);

            if (katastarskaOpstina == null)
            {
                return BadRequest("Ne postoji katastarska opština sa prosleđenim ID-jem");
            }

            var parcela = mapper.Map<Parcela>(parcelaDTO);
            parcelaRepository.Update(parcela, parcela.Id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var parcela = parcelaRepository.GetById(id);

            if (parcela == null)
            {
                return NotFound();
            }

            parcelaRepository.Delete(id);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("vo/{parcelaId}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult<ParcelaInfoDTO> GetParceleZaDrugeServiseByID(int parcelaId)
        {
            var parcela = parcelaRepository.GetParcelaByIdVO(parcelaId);
            if (parcela == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<ParcelaInfoDTO>(parcela));

        }
    }
}
