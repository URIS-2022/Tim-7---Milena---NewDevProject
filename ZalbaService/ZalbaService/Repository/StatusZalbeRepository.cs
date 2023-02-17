using AutoMapper;
using ZalbaService.Entities;

namespace ZalbaService.Repository
{
    public class StatusZalbeRepository : IStatusZalbeRepository
    {
        private readonly DataContext context;
        private readonly IMapper mapper;
        public StatusZalbeRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;   
        }

        public StatusZalbe CreateStatusZalbe(StatusZalbe statusZalbe)
        {
            statusZalbe.StatusZalbeID = Guid.NewGuid();
            var createdEntity = context.StatusZalbe.Add(statusZalbe);
            context.SaveChanges();
            return mapper.Map<StatusZalbe>(createdEntity.Entity);
        }

        public void DeleteStatusZalbe(Guid StatusZalbeID)
        {
            var statusZalbe = GetStatusZalbe(StatusZalbeID);
            context.Remove(statusZalbe);
            context.SaveChanges();
        }

        public List<StatusZalbe> GetStatusiZalbi()
        {
            return context.StatusZalbe.ToList();

        }

        public StatusZalbe GetStatusZalbe(Guid StatusZalbeID)
        {
            return context.StatusZalbe.FirstOrDefault(e => e.StatusZalbeID == StatusZalbeID);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public void UpdateStatusZalbe(StatusZalbe statusZalbe)
        {
            throw new NotSupportedException();
        }
    }
}
