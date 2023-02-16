using Gateway.Models.JavnoNadmetanje;

namespace Gateway.Models.Oglas
{
    public class OglasDto
    {
        public int OglasId { get; set; }
        public DateTime DatumObjave { get; set; }
        public DateTime RokZaZalbu { get; set; }
        public string? OpisOglasa { get; set; }
        public int ObjavljenUListuId { get; set; }
        public JavnoNadmetanjeDto? JavnoNadmetanje { get; set; }
    }
}
