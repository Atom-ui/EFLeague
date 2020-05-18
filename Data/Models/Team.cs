using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Team
    {
        public Team(int stamnummer, string naam, string bijnaam, string trainer)
        {
            Stamnummer = stamnummer;
            Naam = naam;
            Bijnaam = bijnaam;
            Trainer = trainer;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Stamnummer { get; set; }
        public string Naam { get; set; }
        public string Bijnaam { get; set; }
        public string Trainer { get; set; }
        public List<Speler> Spelers { get; set; } = new List<Speler>();
        public void AddSpeler(Speler speler)
        {
            Spelers.Add(speler);
        }
        public void RemoveSpeler(Speler speler)
        {
            Spelers.Remove(speler);
        }
        public override string ToString()
        {
            string start = $"Stamnummer: {Stamnummer}, Naam: {Naam}, Bijnaam: {Bijnaam}, Trainer: {Trainer}";
            foreach (var s in Spelers)
                start += $"\n   {s.ToString()}";
            return start;
        }
    }
}
