using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OglasURIS.DTO;
using OglasURIS.Interfaces;
using OglasURIS.Models;
using OglasURIS.ServiceCalls;

namespace OglasURIS.Controllers
{

    /// <summary>
    /// Predstavlja kontroler oglasa
    /// </summary>

    [Route("api/Oglas")]
    [ApiController]
    public class OglasController : ControllerBase
    {
        private readonly IOglasRepository oglasRepository;
        private readonly IMapper mapper;
        private readonly IJavnoNadmetanjeService javnoNadmetanjeService;

        public OglasController(IOglasRepository oglasRepository, IMapper mapper, IJavnoNadmetanjeService javnoNadmetanjeService)
        {
            this.oglasRepository = oglasRepository;
            this.mapper = mapper;
            this.javnoNadmetanjeService = javnoNadmetanjeService;
        }


        /// <summary>
        /// Vraća sve oglase 
        /// </summary>
        /// <returns>Listu oglasa</returns>

        [HttpGet]
        public ActionResult<IEnumerable<OglasDto>> GetAll()
        {
            List<OglasDto> oglasi = mapper.Map<List<OglasDto>>(oglasRepository.GetAll().ToList());
            foreach (var o in oglasi)
            {
                JavnoNadmetanjeInfoDto javnoNadmetanje = javnoNadmetanjeService.GetJavnoNadmetanjeById((Guid)o.JavnoNadmetanjeId).Result;
                o.JavnoNadmetanje = javnoNadmetanje;
            }
                return Ok(oglasi);

            }

            /// <summary>
            /// Vraća oglas po zadatoj vrednosti id-a
            /// </summary>
            /// <param name="OglasId"></param>
            /// <returns>Objekat oglasa</returns>

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OglasDto> GetById(int id)
        {
            var oglas = mapper.Map<OglasDto>(oglasRepository.GetById(id));

            JavnoNadmetanjeInfoDto javnoNadmetanje = javnoNadmetanjeService.GetJavnoNadmetanjeById((Guid)oglas.JavnoNadmetanjeId).Result;
            oglas.JavnoNadmetanje = javnoNadmetanje;

            if (id == 0)
            {
                return BadRequest();
            }
            

            if (oglas == null)
            {
                return NotFound();
            }
            return Ok(oglas);
        }

        /// <summary>
        /// Kreira novi oglas
        /// </summary>
        /// <param name="oglas"></param>
        /// <returns>Potvrdu o kreiranom oglasu</returns>
        /// <response code="204">Predsednik uspesno obrisan</response>
        /// <response code="400">Poslat neispravan zahtev</response>
        /// <response code="404">Nije pronadjen predsednik za brisanje</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OglasDto> Post([FromBody] OglasCreationDto oglasDto)
        {
            if (oglasDto == null)
            {
                return BadRequest(oglasDto);
            }
            if (oglasDto.OglasId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var oglas = mapper.Map<Oglas>(oglasDto);
            oglasRepository.Add(oglas);

            return Ok(oglas);
        }


        /// <summary>
        /// Menja vrednosti postojećeg oglasa
        /// </summary>
        /// <param name="Oglas"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpPut("{id:int}")]
        public ActionResult<OglasDto> Update(int id, [FromBody] OglasDto oglasDto)
        {
            if (oglasDto == null || id != oglasDto.OglasId)
            {
                return BadRequest();
            }

            var oglas = oglasRepository.GetById(id);
            oglas.DatumObjave = oglasDto.DatumObjave;
            oglas.OpisOglasa = oglasDto.OpisOglasa;
            oglas.RokZaZalbu = oglasDto.RokZaZalbu;
            oglas.ObjavljenUListuId = oglasDto.ObjavljenUListuId;
            oglasRepository.Update(oglas, oglas.OglasId);

            return Ok(oglas);
        }


        /// <summary>
        /// Briše oglas po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="OglasId"></param>

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteOglas(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var oglas = oglasRepository.GetById(id);

            if (oglas == null)
            {
                return NotFound();
            }
            oglasRepository.Delete(id);
            return Ok("Oglas uspesno obrisan");
        }

    }


}
