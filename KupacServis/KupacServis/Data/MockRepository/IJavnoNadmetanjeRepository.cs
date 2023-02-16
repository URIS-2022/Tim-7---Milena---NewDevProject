using KupacServis.Models.Mock;

namespace KupacServis.Data.MockRepository
{
    public interface IJavnoNadmetanjeRepository
    {
        public List<JavnoNadmetanjeDto> GetJavnaNadmetanja();
        public JavnoNadmetanjeDto GetJavnoNadmetanjeById(Guid javnoNadmetanjeId);
    }
}
