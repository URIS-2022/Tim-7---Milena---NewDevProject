using KupacServis.Entities;

namespace KupacServis.Data
{
    public class FizickoLiceRepository:IFizickoLiceRepository
    {
        private KupacContext _context;

        public KupacContext _Context
        {
            get { return _context; }
            set { _context = value; }
        }
        public FizickoLiceRepository(KupacContext context)
        {
            _context = context;
        }

        public List<FizickoLice> GetFizickoLices()
        {
            return _context.FizickoLices.OrderBy(p => p.FizickoLiceId).ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public FizickoLice CreateFizickoLice(FizickoLice fizickoLice)
        {
            fizickoLice.FizickoLiceId = Guid.NewGuid();
            _context.FizickoLices.Add(fizickoLice);
            return fizickoLice;
        }

        public void DeleteFizickoLice(Guid fizickoLiceId)
        {
            _context.FizickoLices.Remove(_context.FizickoLices.FirstOrDefault(l => l.FizickoLiceId == fizickoLiceId));
        }

        public FizickoLice GetFizickoLiceById(Guid fizickoLiceId)
        {
            return _context.FizickoLices.Where(p => p.FizickoLiceId == fizickoLiceId).FirstOrDefault();
        }

        public void UpdateFizickoLice(FizickoLice fizickoLice)
        {
            throw new NotImplementedException();
        }


    }
}
