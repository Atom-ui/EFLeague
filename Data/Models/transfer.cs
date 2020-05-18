using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Transfer
    {
        public Transfer(int prijs)
        {
            Prijs = prijs;
        }

        public Transfer(Speler speler, int prijs, Team oudeClub, Team nieuweClub)
        {
            Speler = speler;
            Prijs = prijs;
            OudeClub = oudeClub;
            NieuweClub = nieuweClub;
        }

        public int Id { get; set; }
        public Speler Speler { get; set; }
        public int Prijs { get; set; }
        public Team OudeClub { get; set; }
        public Team NieuweClub { get; set; }
        public override string ToString()
        {
            return $"Speler: {Speler.Naam}, Prijs: {Prijs}, nieuwe club: {NieuweClub.Stamnummer}, oude club: {OudeClub.Stamnummer}";
        }
    }
}
