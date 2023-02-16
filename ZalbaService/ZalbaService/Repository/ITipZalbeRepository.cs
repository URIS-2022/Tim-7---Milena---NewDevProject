using ZalbaService.Entities;

namespace ZalbaService.Repository
{
    public interface ITipZalbeRepository
    {
        public bool SaveChanges();
        List<TipZalbe> GetTipoviZalbi();
        TipZalbe GetTipZalbe(Guid TipZalbeID);
        TipZalbe CreateTipZalbe(TipZalbe tipZalbe);
        void UpdateTipZalbe(TipZalbe zalba);
        void DeleteTipZalbe(Guid TipZalbeID);
    }
}
