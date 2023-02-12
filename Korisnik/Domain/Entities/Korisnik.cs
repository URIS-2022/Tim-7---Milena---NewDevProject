namespace Domain.Entities
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public byte[] LozinkaHash { get; set; }
        public byte[] LozinkaSalt { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
    }
}
