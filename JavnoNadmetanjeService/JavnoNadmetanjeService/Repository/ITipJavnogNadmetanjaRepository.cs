using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Repository
{
    public interface ITipJavnogNadmetanjaRepository
    {
        public bool SaveChanges();
        List<TipJavnogNadmetanja> GetTipoviJavnogNadmetanja();
        TipJavnogNadmetanja GetTipJavnogNadmetanja(Guid TipJavnogNadmetanjaID);
        TipJavnogNadmetanja CreateTipJavnogNadmetanja(TipJavnogNadmetanja tipJavnogNadmetanja);
        void UpdateTipJavnogNadmetanja(TipJavnogNadmetanja tipJavnogNadmetanja);
        void DeleteTipJavnogNadmetanja(Guid TipJavnogNadmetanjaID);
    }
}
