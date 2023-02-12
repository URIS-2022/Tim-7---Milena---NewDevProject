namespace Gateway.Models.Parcela
{
    public class KvalitetZemljistaDTO
    {
        public int Id { get; set; }

        public string NazivVrsteZemljista { get; set; }

        public Kvalitet Kvalitet { get; set; }
    }

    public enum Kvalitet
    {
        Nizak, Srednji, Visok
    }
}
