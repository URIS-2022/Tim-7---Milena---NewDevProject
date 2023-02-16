using KupacServis.Entities;
using KupacServis.Models;

namespace KupacServis.Data
{
    public interface IKupacRepository
    {
        List<Kupac> GetKupacs();
        Kupac CreateKupac(Kupac kupac);

        Kupac GetKupacById(Guid kupacId);

        void DeleteKupac(Guid kupacId);

        void UpdateKupac(Kupac stariKupac,Kupac noviKupac);

        Kupac GetKupacByIdVO(Guid kupacId);
        List<KupacOvlascenoLice> GetKupacByOvlascenoLiceId(Guid ovlascenoLiceId);

        bool SaveChanges();
    }
}
