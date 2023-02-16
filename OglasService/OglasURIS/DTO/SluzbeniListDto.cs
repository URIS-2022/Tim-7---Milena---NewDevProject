using OglasURIS.Models;

namespace OglasURIS.DTO
{
    /// <summary>
    /// Predstavlja model službenog lista
    /// </summary>
    public class SluzbeniListDto
    {
        /// <summary>
        /// Id sluzbenog lista
        /// </summary>
        public int SluzbeniListId { get; set; }

        /// <summary>
        /// Datum izdavanja službenog lista
        /// </summary>
        public DateTime DatumIzdanja { get; set; }

        /// <summary>
        /// Broj lista
        /// </summary>
        public int BrojLista { get; set; }

        /// <summary>
        /// Lista oglasa koji su objavljeni u službenom listu
        /// </summary>
        public List<int> ListaOglasa { get; set; }

        public SluzbeniListDto()
        {

        }
    }
}
