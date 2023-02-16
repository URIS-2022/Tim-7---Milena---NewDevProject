namespace Gateway.Models.Zakup
{
    public class DokumentConfirmationDto
    {
        public Guid DokumentID { get; set; }
        public string? ZavodniBroj { get; set; }
        public DateTime Datum { get; set; }
        public DateTime DatumDonosenja { get; set; }
        public string? Sablon { get; set; }
    }
}
