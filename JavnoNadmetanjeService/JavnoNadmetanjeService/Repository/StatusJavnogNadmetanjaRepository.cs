using AutoMapper;
using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Repository
{
    public class StatusJavnogNadmetanjaRepository : IStatusJavnogNadmetanjaRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public StatusJavnogNadmetanjaRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public StatusJavnogNadmetanja CreateStatusJavnogNadmetanja(StatusJavnogNadmetanja statusJavnogNadmetanja)
        {
            statusJavnogNadmetanja.StatusJavnogNadmetanjaID = Guid.NewGuid();
            var createdEntity = context.StatusJavnogNadmetanja.Add(statusJavnogNadmetanja);
            context.SaveChanges();
            return mapper.Map<StatusJavnogNadmetanja>(createdEntity.Entity);
        }

        public void DeleteStatusJavnogNadmetanja(Guid StatusJavnogNadmetanjaID)
        {
            var statusJavnogNadmetanja = GetStatusJavnogNadmetanja(StatusJavnogNadmetanjaID);
            context.Remove(statusJavnogNadmetanja);
            context.SaveChanges();
        }

        public StatusJavnogNadmetanja GetStatusJavnogNadmetanja(Guid StatusJavnogNadmetanjaID)
        {
            return context.StatusJavnogNadmetanja.FirstOrDefault(e => e.StatusJavnogNadmetanjaID == StatusJavnogNadmetanjaID);
        }

        public List<StatusJavnogNadmetanja> GetStatusiJavnogNadmetanja()
        {
            return context.StatusJavnogNadmetanja.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateStatusJavnogNadmetanja(StatusJavnogNadmetanja statusJavnogNadmetanja)
        {
            throw new NotSupportedException();
        }
    }
}
