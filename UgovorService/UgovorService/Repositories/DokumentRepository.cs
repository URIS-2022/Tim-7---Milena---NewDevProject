using AutoMapper;
using UgovorService.Entities;

namespace UgovorService.Repositories
{
    public class DokumentRepository : IDokumentRepository
    {

        private readonly DataContext context;
        private readonly IMapper mapper;

        public DokumentRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Dokument CreateDokument(Dokument dokument)
        {
            dokument.DokumentID = Guid.NewGuid();
            var createdEntity = context.Dokument.Add(dokument);
            context.SaveChanges();
            return mapper.Map<Dokument>(createdEntity.Entity);
        }

        public void DeleteDokument(Guid DokumentID)
        {
            var dokument = GetDokument(DokumentID);
            context.Remove(dokument);
            context.SaveChanges();
        }
        public List<Dokument> GetDokumente()
        {
            return context.Dokument.ToList();
        }

        public Dokument GetDokument(Guid DokumentID)
        {
            return context.Dokument.FirstOrDefault(e => e.DokumentID == DokumentID);
        }

        

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateDokument(Dokument stariDokument, Dokument noviDokument)
        {
            context.Remove(stariDokument);
            context.Dokument.Add(noviDokument);
            context.SaveChanges();
        }
    }
}
