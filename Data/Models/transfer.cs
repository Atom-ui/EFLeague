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

        public int Id { get; set; }
        public Speler Speler { get; set; }
        public int Prijs { get; set; }
        public Team OudeClub { get; set; }
        public Team NieuweClub { get; set; }
    }
}
