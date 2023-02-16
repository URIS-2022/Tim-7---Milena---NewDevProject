using KupacServis.Entities;

namespace KupacServis.Data
{
    public class PrioritetRepository:IPrioritetRepository
    {
        public KupacContext _context;
        public PrioritetRepository(KupacContext context)
        {
            _context = context;
        }

        public List<Prioritet> GetPrioritets()
        {
            return _context.Prioritets.OrderBy(p => p.PrioritetId).ToList();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public Prioritet CreatePrioritet(Prioritet prioritet)
        {
            prioritet.PrioritetId = Guid.NewGuid();
            _context.Prioritets.Add(prioritet);
            return prioritet;
        }

        public void DeletePrioritet(Guid prioritetId)
        {
            _context.Prioritets.Remove(_context.Prioritets.FirstOrDefault(l => l.PrioritetId == prioritetId));
        }

        public Prioritet GetPrioritetById(Guid prioritetId)
        {
            return _context.Prioritets.Where(p => p.PrioritetId == prioritetId).FirstOrDefault();
        }

        public void UpdatePrioritet(Prioritet prioritet)
        {
            throw new NotImplementedException();
        }



    }
}
