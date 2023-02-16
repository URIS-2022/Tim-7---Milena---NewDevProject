﻿namespace JavnoNadmetanjeService.Models
{
    public class JavnoNadmetanjeUpdateDTO
    {
        public Guid JavnoNadmetanjeID { get; set; }
        public DateTime Datum { get; set; }
        public string VremePocetka { get; set; }
        public string VremeKraja { get; set; }
        public int PocetnaCenaPoHektaru { get; set; }
        public bool Izuzeto { get; set; }
        public Guid TipJavnogNadmetanjaID { get; set; }
        public Guid StatusJavnogNadmetanjaID { get; set; }
        public int IzlicitiranaCena { get; set; }
        public int PeriodZakupa { get; set; }
        public int BrojUcesnika { get; set; }
        public int VisinaDopuneDepozita { get; set; }
        public int Krug { get; set; }
        public List<Guid> Licitanti { get; set; }
        public List<Guid> PrijavljeniKupci { get; set; }
        public List<int> Parcela { get; set; }

    }
}
