using AutoMapper;
using UgovorService.Entities;

namespace UgovorService.Repositories
{
    public class UgovorRepository : IUgovorRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public UgovorRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public Ugovor CreateUgovor(Ugovor ugovor)
        {
            ugovor.UgovorID = Guid.NewGuid();
            var createdEntity = context.Ugovor.Add(ugovor);
            context.SaveChanges();
            return mapper.Map<Ugovor>(createdEntity.Entity);
        }

        public void DeleteUgovor(Guid UgovorID)
        {
            var ugovor = GetUgovor(UgovorID);
            context.Remove(ugovor);
            context.SaveChanges();
        }

        public Ugovor GetUgovor(Guid UgovorID)
        {
            return context.Ugovor.FirstOrDefault(e => e.UgovorID == UgovorID);
        }

        public List<Ugovor> GetUgovore()
        {
            return context.Ugovor.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateUgovor(Ugovor stariUgovor, Ugovor noviUgovor)
        {
            context.Remove(stariUgovor);
            context.Ugovor.Add(noviUgovor);
            context.SaveChanges();
        }
    }
}
