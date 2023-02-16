using LicitacijaServis.Models;


namespace LicitacijaServis.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        public  Task<JavnoNadmetanjeInfoDto> GetJavnoNadmetanjeById(Guid javnoNadmetanjeId);
        
    }
}
