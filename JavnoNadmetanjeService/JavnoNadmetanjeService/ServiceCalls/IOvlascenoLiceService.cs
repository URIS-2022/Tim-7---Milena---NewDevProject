using JavnoNadmetanjeService.Models;

namespace JavnoNadmetanjeService.ServiceCalls
{
    public interface IOvlascenoLiceService
    {
        public Task<OvlascenoLiceInfoDto> GetOvlascenoLiceById(Guid OvlascenoLiceID);
    }
}
