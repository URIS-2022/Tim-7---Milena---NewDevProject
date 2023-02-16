using AdresaService.Entities;
using AutoMapper;

namespace AdresaService.Repositories
{
    public class AdresaRepository : IAdresaRepository

    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public AdresaRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Adresa CreateAdresa(Adresa adresa)
        {
            adresa.AdresaID = Guid.NewGuid();
            var createdEntity = context.Adresa.Add(adresa);
            context.SaveChanges();
            return mapper.Map<Adresa>(createdEntity.Entity);
        }

        public void DeleteAdresa(Guid AdresaID)
        {
            var adresa = GetAdresa(AdresaID);
            context.Remove(adresa);
            context.SaveChanges();
        }

        public Adresa GetAdresa(Guid AdresaID)
        {
            return context.Adresa.FirstOrDefault(e => e.AdresaID == AdresaID);
        }

        public List<Adresa> GetAdrese()
        {
            return context.Adresa.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateAdresa(Adresa staraAdresa, Adresa novaAdresa)
        {
            context.Remove(staraAdresa);
            context.Adresa.Add(novaAdresa);
            context.SaveChanges();
        }
    }
}
