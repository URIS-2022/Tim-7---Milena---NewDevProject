using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Repository
{
    public interface IStatusJavnogNadmetanjaRepository
    {
        public bool SaveChanges();
        List<StatusJavnogNadmetanja> GetStatusiJavnogNadmetanja();
        StatusJavnogNadmetanja GetStatusJavnogNadmetanja(Guid StatusJavnogNadmetanjaID);
        StatusJavnogNadmetanja CreateStatusJavnogNadmetanja(StatusJavnogNadmetanja statusJavnogNadmetanja);
        void UpdateStatusJavnogNadmetanja(StatusJavnogNadmetanja statusJavnogNadmetanja);
        void DeleteStatusJavnogNadmetanja(Guid StatusJavnogNadmetanjaID);
    }
}
