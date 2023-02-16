namespace Gateway.Models.Komisija
{
    public class KomisijaDto
    {   
        public int KomisijaId { get; set; }
        
        public int PredsednikId { get; set; }
        
        public List<int>? ClanId { get; set; }
    }
}
