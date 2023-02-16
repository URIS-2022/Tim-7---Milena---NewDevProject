﻿namespace Korisnik.Entities
{
    /// <summary>
    /// Predstavlja model tipa korisnika
    /// </summary>
    public class TipKorisnikaEntity
    {
        /// <summary>
        /// Id tipa korisnika
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Naziv tipa korisnika
        /// </summary>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Naziv { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
