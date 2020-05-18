using Data.Models;
using System;
using Data;
using System.Linq;

namespace LeagueApp
{
    class Program
    {
        static void Main()
        {
            DatabaseManager dbmng = new DatabaseManager();

            //dbmng.InitialiseerDatabank(@"C:\Users\davy\Documents\data\EFLeague\foot.csv");

            //Speler speler1 = dbmng.SelecteerSpeler(5);
            //////Console.WriteLine(speler1);
            ////speler1.Naam = "trolololol";
            //////dbmng.UpdateSpeler(speler1);
            //Team nieuwTeam = dbmng.SelecteerTeam(3);

            //dbmng.UpdateSpeler(speler1);
            //Transfer transfer = new Transfer(speler1, 10, speler1.Team, nieuwTeam);
            //dbmng.VoegTransferToe(transfer);

            Transfer tr = dbmng.SelecteerTranfer(5);
            Console.WriteLine(tr);
        }
    }
}
