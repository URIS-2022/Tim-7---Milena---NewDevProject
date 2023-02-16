namespace Gateway.Models.Komisija
{
    public class PredsednikDto
    {      
        public int PredsednikId { get; set; }
        /// <summary>
        /// Ime predsednika komisije
        /// </summary>       
        public string? ImePredsednika { get; set; }
        /// <summary>
        /// Prezime predsednika komisije
        /// </summary>       
        public string? PrezimePredsednika { get; set; }
        /// <summary>
        /// Email predsednika komisije
        /// </summary>     
        public string? EmailPredsednika { get; set; }
    }
}
