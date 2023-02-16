namespace Gateway.Models.Zakup
{
    public class UgovorConfirmationDto
    {
        public Guid UgovorID { get; set; }
        public string? ZavodniBrojUgovora { get; set; }
        public DateTime DatumZavodjenja { get; set; }
        public DateTime RokZaVracanjeZemljista { get; set; }
        public string? MestoPotpisa { get; set; }
        public DateTime DatumPotpisa { get; set; }
        public Guid TipGarancijeID { get; set; }
        public Guid DokumentID { get; set; }
    }
}
