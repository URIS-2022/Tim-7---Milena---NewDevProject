using ZalbaService.Entities;

namespace ZalbaService.Repository
{
    public interface IRadnjaNaOsnovuZalbeRepository
    {
        public bool SaveChanges();
        List<RadnjaNaOsnovuZalbe> GetRadnjeNaOsnovuZalbi();
        RadnjaNaOsnovuZalbe GetRadnjaNaOsnovuZalbe(Guid RadnjaNaOsnovuZalbeID);
        RadnjaNaOsnovuZalbe CreateRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe);
        void UpdateRadnjaNaOsnovuZalbe(RadnjaNaOsnovuZalbe RadnjaNaOsnovuZalbe);
        void DeleteRadnjaNaOsnovuZalbe(Guid RadnjaNaOsnovuZalbeID);
    }
}
