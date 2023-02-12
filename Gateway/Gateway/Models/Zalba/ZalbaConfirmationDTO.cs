namespace Gateway.Models.Zalba
{
    public class ZalbaConfirmationDTO
    {
        public Guid ZalbaID { get; set; }
        public DateTime DatumPodnosenjaZalbe { get; set; }
        public string RazlogZalbe { get; set; }
        public string BrojNadmetanja { get; set; }
        public DateTime DatumResenja { get; set; }
        public Guid TipZalbeID { get; set; }
        public Guid StatusZalbeID { get; set; }

        public Guid RadnjaNaOsnovuZalbeID { get; set; }

    }
}
