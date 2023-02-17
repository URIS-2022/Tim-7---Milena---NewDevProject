using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OglasURIS.DTO;
using OglasURIS.Interfaces;
using OglasURIS.Models;

namespace OglasURIS.Controllers
{
    [Route("api/SluzbeniList")]
    [ApiController]
    public class SluzbeniListController : ControllerBase
    {
        private readonly ISluzbeniListRepository sluzbeniListRepository;
        private readonly IMapper mapper;
        private readonly IOglasRepository oglasRepository;

        public SluzbeniListController(ISluzbeniListRepository sluzbeniListRepository, IMapper mapper, IOglasRepository oglasRepository)
        {
            this.sluzbeniListRepository = sluzbeniListRepository;
            this.mapper = mapper;
            this.oglasRepository = oglasRepository;
        }


        /// <summary>
        /// Vraća sve službene listove 
        /// </summary>
        /// <param name="SluzbeniListId"></param>
        /// <returns>Listu službenih listova</returns>

        [HttpGet]
        public ActionResult<IEnumerable<SluzbeniListGetDto>> GetAll()
        {
            var sluzbeniListDb = sluzbeniListRepository.GetAll(includeProperties: "ListaOglasa");
            List<SluzbeniListGetDto> sluzbeniList = new List<SluzbeniListGetDto>();

            foreach (var k in sluzbeniListDb)
            {
                sluzbeniList.Add(new SluzbeniListGetDto(k));
            }
            return Ok(sluzbeniList);
        }

        /// <summary>
        /// Vraća službeni list po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="SluzbeniListId"></param>
        /// <returns>Objekat službenog lista</returns>

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SluzbeniListGetDto> GetById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var sluzbeniListDb = sluzbeniListRepository.GetById(x => x.SluzbeniListId == id, includeProperties: "ListaOglasa");

            if (sluzbeniListDb == null)
            {
                return NotFound();
            }

            return Ok(new SluzbeniListGetDto(sluzbeniListDb));
        }

        /// <summary>
        /// Kreira novi službeni list
        /// </summary>
        /// <param name="SluzbeniList"></param>
        /// <returns>Potvrdu o kreiranom službenom listu</returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SluzbeniListDto> CreateSluzbeniList([FromBody] SluzbeniListDto sluzbeniListDto)
        {

            if (sluzbeniListDto == null)
            {
                return BadRequest(sluzbeniListDto);
            }
            if (sluzbeniListDto.SluzbeniListId > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            
            SluzbeniList sluzbenilist = new SluzbeniList();



            List<Oglas> oglasi = new List<Oglas>();
            foreach (var x in sluzbeniListDto.ListaOglasa)
                oglasi.Add(oglasRepository.GetById(x));
            sluzbenilist.ListaOglasa = oglasi;
            sluzbenilist.DatumIzdanja = sluzbeniListDto.DatumIzdanja;
            sluzbenilist.BrojLista = sluzbeniListDto.BrojLista; 
            sluzbeniListRepository.Add(sluzbenilist);

            return Ok(sluzbenilist);

        }


        /// <summary>
        /// Menja vrednosti postojećeg službenog lista
        /// </summary>
        /// <param name="SluzbeniList"></param>
        /// <returns>Potvrdu o izmenjenom objektu</returns>

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<SluzbeniListDto> UpdateSluzbeniList(int id, [FromBody] SluzbeniListDto sluzbeniListDto)
        {
            if (sluzbeniListDto == null)
            {
                return BadRequest(sluzbeniListDto);
            }
            
            var sluzbenilist = sluzbeniListRepository.GetById(x => x.SluzbeniListId == id, includeProperties: "ListaOglasa");

            List<Oglas> oglasi = new List<Oglas>();
            foreach (var x in sluzbeniListDto.ListaOglasa)
                oglasi.Add(oglasRepository.GetById(x));
            sluzbenilist.ListaOglasa = oglasi;
            sluzbenilist.DatumIzdanja = sluzbeniListDto.DatumIzdanja;
            sluzbenilist.BrojLista = sluzbeniListDto.BrojLista;
            sluzbeniListRepository.Update(sluzbenilist, id);

            return Ok(sluzbenilist);
        }


        /// <summary>
        /// Briše službeni list po zadatoj vrednosti id-a
        /// </summary>
        /// <param name="SluzbeniListId"></param>

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSluzbeniList(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var sluzbeniList = sluzbeniListRepository.GetById(x => x.SluzbeniListId == id, includeProperties: "ListaOglasa");

            if (sluzbeniList == null)
            {
                return NotFound();
            }
            sluzbeniListRepository.Delete(id);
            return Ok("Sluzbeni list uspesno obrisan");
        }


    }
}
