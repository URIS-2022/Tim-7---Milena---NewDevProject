using UgovorService.Models;

namespace UgovorService.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        public Task<JavnoNadmetanjeInfoDto> GetJavnoNadmetanjeById(Guid JavnoNadmetanjeID);
    }
}
