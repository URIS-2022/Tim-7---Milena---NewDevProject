using AdresaService.Entities;

namespace AdresaService.Repositories
{
    public interface IAdresaRepository
    {
        public bool SaveChanges();
        List<Adresa> GetAdrese();
        Adresa GetAdresa(Guid AdresaID);
        Adresa CreateAdresa(Adresa adresa);
        public void UpdateAdresa(Adresa staraAdresa, Adresa novaAdresa);
        void DeleteAdresa(Guid AdresaID);
    }
}
