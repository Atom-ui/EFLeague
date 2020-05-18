using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace LeagueApp
{
    public class DBManager
    {
        private LeagueContext _lgCtx = new LeagueContext();
        public void InitialiseerDatabank(string path)
        {
            Dictionary<int, Team> teams = new Dictionary<int, Team>();
            using (StreamReader r = new StreamReader(path))
            {
                string line; string naam;
                int nummer; string club;
                int waarde; int stamnr;
                string trainer; string bijnaam;
                string header = r.ReadLine();
                while ((line = r.ReadLine()) != null)
                {
                    string[] data = line.Split(",").Select(d => d.Trim()).ToArray();
                    naam = data[0];
                    nummer = int.Parse(data[1]);
                    club = data[2];
                    waarde = int.Parse(data[3].Replace(" ", ""));
                    stamnr = int.Parse(data[4]);
                    trainer = data[5];
                    bijnaam = data[6];
                    if (!teams.ContainsKey(stamnr))
                        teams.Add(stamnr, new Team(stamnr, club, bijnaam, trainer));
                    teams[stamnr].AddSpeler(new Speler(naam, waarde, teams[stamnr]));
                }
            }
            _lgCtx.Teams.AddRange(teams.Values);
            _lgCtx.SaveChanges();

        }
        public void VoegSpelerToe(Speler speler)
        {
            _lgCtx.Spelers.Add(speler);
            _lgCtx.SaveChanges();
        }
        public void VoegTeamToe(Team team)
        {
            _lgCtx.Teams.Add(team);
            _lgCtx.SaveChanges();
        }
        public void VoegTransferToe(Transfer transfer)
        {
            _lgCtx.Transfers.Add(transfer);
            _lgCtx.SaveChanges();
        }
        public void UpdateSpeler (Speler speler)
        {
            Speler sp = SelecteerSpeler(speler.Id);
            sp = speler;
            _lgCtx.SaveChanges();
        } // Wat moet er hier komen?
        public void UpdateTeam(Team team)
        {

        }
        public Speler SelecteerSpeler(int SpelerId)
        {
            var s = _lgCtx.Spelers.Single(speler => speler.Id == SpelerId); // geeft de speler terug zonder team
            var x = _lgCtx.Teams.Single(team => team.Stamnummer == s.TeamId);
            s.Team = x; // voegt het team toe aan speler;
            var test = _lgCtx.Spelers.Include(speler => speler.Team); // include methode, begrijp ik nog niet
            return s;
        }
        public Team SelecteerTeam(int stamnummer)
        {
            return _lgCtx.Teams.Single(team => team.Stamnummer == stamnummer);
        }
        public Transfer SelecteerTranfer(int transferId)
        {
            return _lgCtx.Transfers.Single(transfer => transfer.Id == transferId);
        }
    }
}
