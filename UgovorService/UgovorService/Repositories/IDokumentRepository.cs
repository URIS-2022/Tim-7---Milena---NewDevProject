using UgovorService.Entities;

namespace UgovorService.Repositories
{
    public interface IDokumentRepository
    {
        public bool SaveChanges();
        List<Dokument> GetDokumente();
        Dokument GetDokument(Guid DokumentID);
        Dokument CreateDokument(Dokument dokument);
        public void UpdateDokument(Dokument stariDokument, Dokument noviDokument);
        void DeleteDokument(Guid DokumentID);
    }
}
