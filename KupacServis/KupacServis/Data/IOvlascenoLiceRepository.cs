using KupacServis.Entities;

namespace KupacServis.Data
{
    public interface IOvlascenoLiceRepository
    {
        List<OvlascenoLice> GetOvlascenoLices();
        OvlascenoLice CreateOvlascenoLice(OvlascenoLice ovlascenoLice);

        OvlascenoLice GetOvlascenoLiceById(Guid ovlascenoLiceId);

        void DeleteOvlascenoLice(Guid ovlascenoLiceId);

        void UpdateOvlascenoLice(OvlascenoLice staroOvlascenoLice,OvlascenoLice novoOvlascenoLice);
        public OvlascenoLice GetOvlascenoLiceByIdVO(Guid ovlascenoLiceId);

        bool SaveChanges();
    }
}
