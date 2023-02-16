namespace OglasURIS.Models
{
    public class Oglas
    {
        public int OglasId { get; set; }
        public DateTime DatumObjave { get; set; }
        public DateTime RokZaZalbu { get; set; }
        public string OpisOglasa { get; set; }
        public int ObjavljenUListuId { get; set; }


        public Guid JavnoNadmetanjeId { get; set; }

    }
}
