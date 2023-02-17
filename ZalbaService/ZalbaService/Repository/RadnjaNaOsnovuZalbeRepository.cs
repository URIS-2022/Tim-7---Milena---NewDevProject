using AutoMapper;
using ZalbaService.Entities;

namespace ZalbaService.Repository
{
    public class RadnjaNaOsnovuZalbeRepository : IRadnjaNaOsnovuZalbeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;

        public RadnjaNaOsnovuZalbeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public RadnjaNaOsnovuZalbe CreateRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe)
        {
            radnjaNaOsnovuZalbe.RadnjaNaOsnovuZalbeID = Guid.NewGuid();
            var createdEntity = context.RadnjaNaOsnovuZalbe.Add(radnjaNaOsnovuZalbe);
            context.SaveChanges();
            return mapper.Map<RadnjaNaOsnovuZalbe>(createdEntity.Entity);
        }

        public void DeleteRadnjaNaOsnovuZalbe(Guid RadnjaNaOsnovuZalbeID)
        {
            var radnjaNaOsnovuZalbe = GetRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbeID);
            context.Remove(radnjaNaOsnovuZalbe);
            context.SaveChanges();
        }

        public RadnjaNaOsnovuZalbe GetRadnjaNaOsnovuZalbe(Guid RadnjaNaOsnovuZalbeID)
        {
            return context.RadnjaNaOsnovuZalbe.FirstOrDefault(e => e.RadnjaNaOsnovuZalbeID == RadnjaNaOsnovuZalbeID);
        }

        public List<RadnjaNaOsnovuZalbe> GetRadnjeNaOsnovuZalbi()
        {
            return context.RadnjaNaOsnovuZalbe.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe)
        {
            throw new NotSupportedException();
        }
    }
}
