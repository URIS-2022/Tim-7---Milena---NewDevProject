using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uris.Models
{
    public class Parcela
    {
        [Required]
        public int Id { get; set; }

        public int BrojParcele { get; set; }

        public int BrojListaNepokretnosti { get; set; }

        public float Povrsina { get; set; }

        public bool ZasticenaZona { get; set; }

        public string OblikSvojine { get; set; }

        public string Odvodnjavanje { get; set; }

        [ForeignKey("Kultura")]
        public int KulturaID { get; set; }

        [ForeignKey("KvalitetZemljista")]
        public int KvalitetZemljistaID { get; set; }

        [ForeignKey("KatastarskaOpstina")]
        public int KatastarskaOpstinaID { get; set; }

        public Guid KupacId { get; set; }
    }
}
