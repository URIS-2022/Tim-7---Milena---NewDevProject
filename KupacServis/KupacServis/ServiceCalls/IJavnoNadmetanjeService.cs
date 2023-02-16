using KupacServis.Models;

namespace KupacServis.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        public  Task<JavnoNadmetanjeInfoDto> GetJavnoNadmetanjeById(Guid javnoNadmetanjeId);
    }
}
