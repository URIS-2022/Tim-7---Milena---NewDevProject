using AutoMapper;
using UgovorService.Entities;

namespace UgovorService.Repositories
{
    public class TipGarancijeRepository : ITipGarancijeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public TipGarancijeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public TipGarancije CreateTipGarancije(TipGarancije tipGarancije)
        {
            tipGarancije.TipGarancijeID = Guid.NewGuid();
            var createdEntity = context.TipGarancije.Add(tipGarancije);
            context.SaveChanges();
            return mapper.Map<TipGarancije>(createdEntity.Entity);
        }

        public void DeleteTipGarancije(Guid TipGarancijeID)
        {
            var tipGarancije = GetTipGarancije(TipGarancijeID);
            context.Remove(tipGarancije);
            context.SaveChanges();
        }

        public TipGarancije GetTipGarancije(Guid TipGarancijeID)
        {
            return context.TipGarancije.FirstOrDefault(e => e.TipGarancijeID == TipGarancijeID);
        }

        public List<TipGarancije> GetTipoveGarancija()
        {
            return context.TipGarancije.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateTipGarancije(TipGarancije stariTipGarancije, TipGarancije noviTipGarancije)
        {
            context.Remove(stariTipGarancije);
            context.TipGarancije.Add(noviTipGarancije);
            context.SaveChanges();
        }
    }
}
