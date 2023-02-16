namespace Gateway.Models.Parcela
{
    public class KvalitetZemljistaDto
    {
        public int Id { get; set; }

        public string? NazivVrsteZemljista { get; set; }

        public Kvalitet Kvalitet { get; set; }
    }

    public enum Kvalitet
    {
        Nizak, Srednji, Visok
    }
}
