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

        public override bool Equals(object obj)
        {
            return obj is Speler speler &&
                   Id == speler.Id &&
                   Naam == speler.Naam &&
                   Waarde == speler.Waarde &&
                   TeamId == speler.TeamId &&
                   EqualityComparer<Team>.Default.Equals(Team, speler.Team);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Naam, Waarde, TeamId, Team);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Naam: {Naam}, Geschatte Waarde: {Waarde}, TeamId: {TeamId}, Teamnaam: {Team.Naam}";
        }
    }
}
