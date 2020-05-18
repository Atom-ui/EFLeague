using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Speler
    {
        public Speler(string naam, int waarde)
        {
            Naam = naam;
            Waarde = waarde;
        }

        public Speler(string naam, int waarde, Team team)
        {
            Naam = naam;
            Waarde = waarde;
            Team = team;
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public int Waarde { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Naam: {Naam}, Geschatte Waarde: {Waarde}, TeamId: {TeamId}, Teamnaam: {Team.Naam}";
        }
    }
}
