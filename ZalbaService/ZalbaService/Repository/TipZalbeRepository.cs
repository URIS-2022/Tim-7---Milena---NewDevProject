using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ZalbaService.Entities;

namespace ZalbaService.Repository
{
    public class TipZalbeRepository:ITipZalbeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public TipZalbeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
        public TipZalbe CreateTipZalbe(TipZalbe tipZalbe)
        {
            tipZalbe.TipZalbeID = Guid.NewGuid();
            var createdEntity = context.TipZalbe.Add(tipZalbe);
            context.SaveChanges();
            return mapper.Map<TipZalbe>(createdEntity.Entity);
        }

        public void DeleteTipZalbe(Guid TipZalbeID)
        {
            var tipZalbe = GetTipZalbe(TipZalbeID);
            context.Remove(tipZalbe);
            context.SaveChanges();
        }

        public List<TipZalbe> GetTipoviZalbi()
        {
            return context.TipZalbe.ToList();
        }

        public TipZalbe GetTipZalbe(Guid TipZalbeID)
        {
            return context.TipZalbe.FirstOrDefault(e => e.TipZalbeID == TipZalbeID);
        }

        public void UpdateTipZalbe(TipZalbe zalba)
        {
            throw new NotSupportedException();
        }
    }
}
