using UgovorService.Entities;

namespace UgovorService.Repositories
{
    public interface IUgovorRepository
    {
        public bool SaveChanges();
        List<Ugovor> GetUgovore();
        Ugovor GetUgovor(Guid UgovorID);
        Ugovor CreateUgovor(Ugovor ugovor);
        public void UpdateUgovor(Ugovor stariUgovor, Ugovor noviUgovor);
        void DeleteUgovor(Guid UgovorID);
    }
}
