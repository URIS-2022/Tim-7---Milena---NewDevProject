using ZalbaService.Entities;

namespace ZalbaService.Repository
{
    public interface IZalbaRepository
    {
        public bool SaveChanges();
        List<Zalba> GetZalbe(string? status = null, string? tip = null);
        Zalba GetZalba(Guid ZalbaID);
        Zalba CreateZalba(Zalba zalba);
        public void UpdateZalba(Zalba staraZalba, Zalba novaZalba);
        void DeleteZalba(Guid ZalbaID);


    }
}
