using Mikroservis_Uplata.DTO;

namespace Mikroservis_Uplata.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        public Task<JavnoNadmetanjeDto> GetJavnoNadmetanjeById(Guid JavnoNadmetanjeID);
    }
}
