using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Data
{
    public class DatabaseManager
    {
        private readonly LeagueContext _lgCtx = new LeagueContext();
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
            transfer.Speler.TeamId = transfer.NieuweClub.Stamnummer;
            UpdateSpeler(transfer.Speler);
        }
        public void UpdateSpeler(Speler speler)
        {
            _ = SelecteerSpeler(speler.Id);
            _lgCtx.SaveChanges();
        }
        public void UpdateTeam(Team team)
        {
            _ = SelecteerTeam(team.Stamnummer);
            _lgCtx.SaveChanges();
        }
        public Speler SelecteerSpeler(int SpelerId)
        {
            return _lgCtx.Spelers.Include(speler => speler.Team).Single(speler => speler.Id == SpelerId);
        }
        public Team SelecteerTeam(int stamnummer)
        {
            return _lgCtx.Teams.Include(team => team.Spelers).Single(team => team.Stamnummer == stamnummer);
        }
        public Transfer SelecteerTranfer(int transferId)
        {
            return _lgCtx.Transfers.Include(transfer => transfer.Speler).Include(t => t.OudeClub).Include(t => t.NieuweClub).Single(t => t.Id == transferId);
        }
    }
}
