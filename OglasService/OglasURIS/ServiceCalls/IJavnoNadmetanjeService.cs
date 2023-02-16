using OglasURIS.DTO;

namespace OglasURIS.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        public Task<JavnoNadmetanjeInfoDto> GetJavnoNadmetanjeById(Guid JavnoNadmetanjeId);
    }
}
