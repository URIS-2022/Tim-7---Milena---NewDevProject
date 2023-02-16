namespace Gateway.Models.Oglas
{
    public class SluzbeniListGetDto
    {
        public int SluzbeniListId { get; set; }
        public DateTime DatumIzdanja { get; set; }
        public int BrojLista { get; set; }
        public List<OglasDto>? ListaOglasa { get; set; }
    }
}
