using AdresaService.Entities;

namespace AdresaService.Repositories
{
    public interface IDrzavaRepository
    {
        public bool SaveChanges();
        List<Drzava> GetDrzave();
        Drzava GetDrzava(Guid DrzavaID);
        Drzava CreateDrzava(Drzava drzava);
        public void UpdateDrzava(Drzava staraDrzava, Drzava novaDrzava);
        void DeleteDrzava(Guid DrzavaID);
    }
}
