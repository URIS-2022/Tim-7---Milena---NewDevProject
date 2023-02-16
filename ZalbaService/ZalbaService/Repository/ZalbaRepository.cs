using ZalbaService.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace ZalbaService.Repository
{
    public class ZalbaRepository : IZalbaRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public ZalbaRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
        public List<Zalba> GetZalbe(string status = null, string tip = null)
        {
            return context.Zalba.Include(z => z.TipZalbe).Include(s => s.StatusZalbe).Include(r => r.RadnjaNaOsnovuZalbe).
                Where(e => (status == null || e.StatusZalbe.NazivStatusaZalbe == status) &&
                           (tip == null || e.TipZalbe.NazivTipaZalbe == tip)).OrderByDescending(z=>z.DatumPodnosenjaZalbe).ToList();
        }

        public Zalba GetZalba(Guid ZalbaID)
        {
            return context.Zalba.Include(z => z.TipZalbe).Include(z => z.StatusZalbe).Include(z => z.RadnjaNaOsnovuZalbe).
                FirstOrDefault(e => e.ZalbaID == ZalbaID);
        }

        public Zalba CreateZalba(Zalba zalba)
        {
            zalba.ZalbaID = Guid.NewGuid();
            var createdEntity =  context.Zalba.Add(zalba);
            context.SaveChanges();
            return mapper.Map<Zalba>(createdEntity.Entity);
        }

        public void UpdateZalba(Zalba staraZalba, Zalba novaZalba)
        {
            context.Remove(staraZalba);
            context.Zalba.Add(novaZalba);
            context.SaveChanges();
        }

        public void DeleteZalba(Guid ZalbaID)
        {
            var zalba = GetZalba(ZalbaID);
            context.Remove(zalba);
            context.SaveChanges();
        }
    }
}
