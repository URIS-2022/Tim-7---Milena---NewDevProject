using KupacServis.Entities;

namespace KupacServis.Data
{
    public interface IPrioritetRepository
    {
        List<Prioritet> GetPrioritets();
        Prioritet CreatePrioritet(Prioritet prioritet);

        Prioritet GetPrioritetById(Guid prioritetId);

        void DeletePrioritet(Guid prioritetId);

        void UpdatePrioritet(Prioritet prioritet);
        bool SaveChanges();
    }
}
