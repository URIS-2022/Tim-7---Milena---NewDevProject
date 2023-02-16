using Mikroservis_Uplata.DTO;

namespace Mikroservis_Uplata.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        public Task<JavnoNadmetanjeDTO> GetJavnoNadmetanjeById(Guid JavnoNadmetanjeID);
    }
}
