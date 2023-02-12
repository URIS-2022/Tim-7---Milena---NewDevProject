namespace Gateway.Models.Komisija
{
    public class KomisijaGetDto
    {     
        public int KomisijaId { get; set; }

        public PredsednikDto Predsednik { get; set; }

        public List<ClanKomisijeDto> Clan { get; set; }
    }
}
