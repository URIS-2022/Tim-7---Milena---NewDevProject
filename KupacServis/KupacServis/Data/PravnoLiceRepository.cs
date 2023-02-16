using KupacServis.Entities;

namespace KupacServis.Data
{
    public class PravnoLiceRepository:IPravnoLiceRepository
    {
        public KupacContext _context;
        public PravnoLiceRepository(KupacContext context)
        {
            _context = context;
        }

        public List<PravnoLice> GetPravnoLices()
        {
            return _context.PravnoLices.OrderBy(p => p.PravnoLiceId).ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public PravnoLice CreatePravnoLice(PravnoLice pravnoLice)
        {
            pravnoLice.PravnoLiceId = Guid.NewGuid(); 
            _context.PravnoLices.Add(pravnoLice);
            return pravnoLice;
        }

        public void DeletePravnoLice(Guid pravnoLiceId)
        {
            _context.PravnoLices.Remove(_context.PravnoLices.FirstOrDefault(l => l.PravnoLiceId == pravnoLiceId));
        }

        public PravnoLice GetPravnoLiceById(Guid pravnoLiceId)
        {
            return _context.PravnoLices.Where(p => p.PravnoLiceId == pravnoLiceId).FirstOrDefault();
        }

        public void UpdatePravnoLice(PravnoLice pravnoLice)
        {
            throw new NotImplementedException();
        }


    }
}
