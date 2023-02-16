using UgovorService.Entities;

namespace UgovorService.Repositories
{
    public interface ITipGarancijeRepository
    {
        public bool SaveChanges();
        List<TipGarancije> GetTipoveGarancija();
        TipGarancije GetTipGarancije(Guid TipGarancijeID);
        TipGarancije CreateTipGarancije(TipGarancije tipGarancije);
        public void UpdateTipGarancije(TipGarancije stariTipGarancije, TipGarancije noviTipGarancije);
        void DeleteTipGarancije(Guid TipGarancijeID);
    }
}
