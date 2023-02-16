namespace JavnoNadmetanjeService.Models
{
    public class KupacInfoDto
    {
        public Guid KupacId { get; set; }
        public int OstvarenaPovrsina { get; set; }
        public bool ImaZabranu { get; set; }
        public string BrTelefona1 { get; set; }
        public string Email { get; set; }

        public string BrRacuna { get; set; }
    }
}
