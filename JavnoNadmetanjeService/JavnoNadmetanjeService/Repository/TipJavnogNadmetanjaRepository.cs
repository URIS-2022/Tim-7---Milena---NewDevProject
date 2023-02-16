using AutoMapper;
using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Repository
{
    public class TipJavnogNadmetanjaRepository: ITipJavnogNadmetanjaRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public TipJavnogNadmetanjaRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public TipJavnogNadmetanja CreateTipJavnogNadmetanja(TipJavnogNadmetanja tipJavnogNadmetanja)
        {
            tipJavnogNadmetanja.TipJavnogNadmetanjaID = Guid.NewGuid();
            var createdEntity = context.TipJavnogNadmetanja.Add(tipJavnogNadmetanja);
            context.SaveChanges();
            return mapper.Map<TipJavnogNadmetanja>(createdEntity.Entity);
        }

        public void DeleteTipJavnogNadmetanja(Guid TipJavnogNadmetanjaID)
        {
            var tipJavnogNadmetanja = GetTipJavnogNadmetanja(TipJavnogNadmetanjaID);
            context.Remove(tipJavnogNadmetanja);
            context.SaveChanges();
        }

        public TipJavnogNadmetanja GetTipJavnogNadmetanja(Guid TipJavnogNadmetanjaID)
        {
            return context.TipJavnogNadmetanja.FirstOrDefault(e => e.TipJavnogNadmetanjaID == TipJavnogNadmetanjaID);
        }

        public List<TipJavnogNadmetanja> GetTipoviJavnogNadmetanja()
        {
            return context.TipJavnogNadmetanja.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateTipJavnogNadmetanja(TipJavnogNadmetanja tipJavnogNadmetanja)
        {

        }
    }
}
