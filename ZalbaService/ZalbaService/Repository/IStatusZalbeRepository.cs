using ZalbaService.Entities;

namespace ZalbaService.Repository
{
    public interface IStatusZalbeRepository
    {
        public bool SaveChanges();
        List<StatusZalbe> GetStatusiZalbi();
        StatusZalbe GetStatusZalbe(Guid StatusZalbeID);
        StatusZalbe CreateStatusZalbe(StatusZalbe statusZalbe);
        void UpdateStatusZalbe(StatusZalbe statusZalbe);
        void DeleteStatusZalbe(Guid StatusZalbeID);
    }
}
