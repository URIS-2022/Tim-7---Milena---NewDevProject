namespace Gateway.Models.Oglas
{
    public class SluzbeniListDto
    {
        public int SluzbeniListId { get; set; }
        public DateTime DatumIzdanja { get; set; }
        public int BrojLista { get; set; }
        public List<int> ListaOglasa { get; set; }
    }
}
