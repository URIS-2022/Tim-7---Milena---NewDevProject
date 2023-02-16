namespace JavnoNadmetanjeService.Models
{
    public class ParcelaInfoDto
    {
        public int Id { get; set; }

        public int BrojParcele { get; set; }

        public int BrojListaNepokretnosti { get; set; }

        public float Povrsina { get; set; }

        public bool ZasticenaZona { get; set; }

        public string OblikSvojine { get; set; }

        public string Odvodnjavanje { get; set; }

        public int KulturaID { get; set; }

        public int KvalitetZemljistaID { get; set; }

        public int KatastarskaOpstinaID { get; set; }
    }
}
