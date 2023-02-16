using KupacServis.Models;

namespace KupacServis.ServiceCalls
{
    public interface IAdresaService
    {
        public  Task<AdresaDto> GetAdresaByID(Guid adresaId);
    }
}
