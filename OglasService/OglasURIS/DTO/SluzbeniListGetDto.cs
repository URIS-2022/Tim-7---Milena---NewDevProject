using OglasURIS.Models;

namespace OglasURIS.DTO
{
    public class SluzbeniListGetDto
    {
        public int SluzbeniListId { get; set; }
        public DateTime DatumIzdanja { get; set; }
        public int BrojLista { get; set; }
        public List<Oglas> ListaOglasa { get; set; }

        public SluzbeniListGetDto()
        {

        }

        public SluzbeniListGetDto(SluzbeniList sluzbeniList)
        {
            SluzbeniListId = sluzbeniList.SluzbeniListId;
            DatumIzdanja = sluzbeniList.DatumIzdanja;
            BrojLista = sluzbeniList.BrojLista;
            ListaOglasa = sluzbeniList.ListaOglasa;
        }
    }
}
