using Gateway.Models.Liciter;

namespace Gateway.Models.Parcela
{
    public class ParcelaDto
    {
        public int Id { get; set; }

        public int BrojParcele { get; set; }

        public int BrojListaNepokretnosti { get; set; }

        public float Povrsina { get; set; }

        public bool ZasticenaZona { get; set; }

        public OblikSvojine OblikSvojine { get; set; }

        public Odvodnjavanje Odvodnjavanje { get; set; }

        public int KulturaID { get; set; }

        public int KvalitetZemljistaID { get; set; }

        public int KatastarskaOpstinaID { get; set; }

        public KupacDto? Kupac { get; set; }
    }

    public enum OblikSvojine
    {
        Susvojina, ZajednickaSvojina, EtaznaSvojina
    }

    public enum Odvodnjavanje
    {
        Tekuce, Eksploataciono, Kombinovano, Kompleksno
    }
}
