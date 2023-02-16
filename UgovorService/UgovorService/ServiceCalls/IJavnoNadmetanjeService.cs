using UgovorService.Models;

namespace UgovorService.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        public Task<JavnoNadmetanjeInfoDTO> GetJavnoNadmetanjeById(Guid JavnoNadmetanjeID);
    }
}
