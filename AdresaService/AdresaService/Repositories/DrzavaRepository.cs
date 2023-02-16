using AdresaService.Entities;
using AutoMapper;

namespace AdresaService.Repositories
{
    public class DrzavaRepository : IDrzavaRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public DrzavaRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Drzava CreateDrzava(Drzava drzava)
        {
            drzava.DrzavaID = Guid.NewGuid();
            var createdEntity = context.Drzava.Add(drzava);
            context.SaveChanges();
            return mapper.Map<Drzava>(createdEntity.Entity);
        }

        public void DeleteDrzava(Guid DrzavaID)
        {
            var drzava = GetDrzava(DrzavaID);
            context.Remove(drzava);
            context.SaveChanges();
        }

        public Drzava GetDrzava(Guid DrzavaID)
        {
            return context.Drzava.FirstOrDefault(e => e.DrzavaID == DrzavaID);
        }

        public List<Drzava> GetDrzave()
        {
            return context.Drzava.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateDrzava(Drzava staraDrzava, Drzava novaDrzava)
        {
            context.Remove(staraDrzava);
            context.Drzava.Add(novaDrzava);
            context.SaveChanges();
        }
    }
}
