namespace KupacServis.Entities
{
    public class KupacOvlascenoLice
    {

        public Guid KupacId { get; set; }

        public Guid OvlascenoLiceId { get; set; }

        public Kupac Kupac { get; set; }
        public OvlascenoLice OvlascenoLice { get; set; }
    }
}
