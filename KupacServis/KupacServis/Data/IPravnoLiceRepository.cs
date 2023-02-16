using KupacServis.Entities;

namespace KupacServis.Data
{
    public interface IPravnoLiceRepository
    {
        List<PravnoLice> GetPravnoLices();
        PravnoLice CreatePravnoLice(PravnoLice pravnoLice);

        PravnoLice GetPravnoLiceById(Guid pravnoLiceId);

        void DeletePravnoLice(Guid pravnoLiceId);

        void UpdatePravnoLice(PravnoLice pravnoLice);
        bool SaveChanges();
    }
}
