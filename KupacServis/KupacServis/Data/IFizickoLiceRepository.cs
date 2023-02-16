using KupacServis.Entities;

namespace KupacServis.Data
{
    public interface IFizickoLiceRepository
    {
        List<FizickoLice> GetFizickoLices();
        FizickoLice CreateFizickoLice(FizickoLice fizickoLice);

        FizickoLice GetFizickoLiceById(Guid fizickoLiceId);

        void DeleteFizickoLice(Guid fizickoLiceId);

        void UpdateFizickoLice(FizickoLice fizickoLice);
        bool SaveChanges();
    }
}
