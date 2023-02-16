using LicitacijaServis.Entities;

namespace LicitacijaServis.Data
{
    public interface ILicitacijaRepository
    {
        List<Licitacija> GetLicitacijas();
        Licitacija CreateLicitacija(Licitacija licitacija);

        Licitacija GetLicitacijaById(Guid licitacijaId);

        void DeleteLicitacija(Guid licitacijaId);

        void UpdateLicitacija(Licitacija staraLicitacija,Licitacija novaLicitacija);
        bool SaveChanges();
    }
}
