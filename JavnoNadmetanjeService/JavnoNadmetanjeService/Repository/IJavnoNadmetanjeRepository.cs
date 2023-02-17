using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Repository
{
    public interface IJavnoNadmetanjeRepository
    {
        public bool SaveChanges();
        List<JavnoNadmetanje> GetJavnaNadmetanja(string? status = null, string? tip = null);
        JavnoNadmetanje GetJavnoNadmetanje(Guid JavnoNadmetanjeID);
        JavnoNadmetanje CreateJavnoNadmetanje(JavnoNadmetanje javnoNadmetanje);
        void UpdateJavnoNadmetanje(JavnoNadmetanje staroJavnoNadmetanje, JavnoNadmetanje novoJavnoNadmetanje);
        void DeleteJavnoNadmetanje(Guid JavnoNadmetanjeID);
        public JavnoNadmetanje GetJavnoNadmetanjeByIdVO(Guid javnoNadmetanjeId);

    }
}
