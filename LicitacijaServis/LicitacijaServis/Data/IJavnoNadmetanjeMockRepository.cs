using LicitacijaServis.Models.Mock;

namespace LicitacijaServis.Data
{
    public interface IJavnoNadmetanjeMockRepository
    {
        public List<JavnoNadmetanjeDto> GetJavnaNadmetanja();

        public JavnoNadmetanjeDto GetJavnoNadmetanjeById(Guid javnoNadmetanjeId);
    }
}
