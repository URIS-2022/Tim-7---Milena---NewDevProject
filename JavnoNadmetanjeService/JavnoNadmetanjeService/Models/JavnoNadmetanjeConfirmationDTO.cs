namespace JavnoNadmetanjeService.Models
{
    public class JavnoNadmetanjeConfirmationDTO
    {
        public Guid JavnoNadmetanjeID { get; set; }
        public DateTime Datum { get; set; }
        public string VremePocetka { get; set; }
        public string VremeKraja { get; set; }
        public int PocetnaCenaPoHektaru { get; set; }
        public int BrojUcesnika { get; set; }
    }
}
