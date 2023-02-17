namespace JavnoNadmetanjeService.Models
{
    public class ParcelaInfoDto
    {
        /// <summary>
        /// ID parcele
        /// </summary> 
        public int Id { get; set; }
        /// <summary>
        /// Broj parcele
        /// </summary> 
        public int BrojParcele { get; set; }
        /// <summary>
        /// Broj liste nepokretnosti
        /// </summary> 
        public int BrojListaNepokretnosti { get; set; }
        /// <summary>
        /// Povrsina parcele
        /// </summary> 
        public float Povrsina { get; set; }
        /// <summary>
        /// Da li je zasticena zona
        /// </summary> 
        public bool ZasticenaZona { get; set; }
        /// <summary>
        /// Oblik svojine
        /// </summary> 
        public string OblikSvojine { get; set; }
        /// <summary>
        /// Odvodnjavanje
        /// </summary> 
        public string Odvodnjavanje { get; set; }
        /// <summary>
        /// ID kulture
        /// </summary> 
        public int KulturaID { get; set; }
        /// <summary>
        /// ID kvaliteta zemljista
        /// </summary> 
        public int KvalitetZemljistaID { get; set; }
        /// <summary>
        /// ID katastarske opstine
        /// </summary> 
        public int KatastarskaOpstinaID { get; set; }
    }
}
