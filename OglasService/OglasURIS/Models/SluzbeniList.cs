namespace OglasURIS.Models
{
    public class SluzbeniList 
    {
        public int SluzbeniListId { get; set; }
        public DateTime DatumIzdanja { get; set; }
        public int BrojLista { get; set; }
        public List<Oglas> ListaOglasa { get; set; }
    }
}
