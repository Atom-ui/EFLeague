using Data.Models;
using System;

namespace LeagueApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DBManager mng = new DBManager();
            Team team = new Team(1, "test", "bijtest", "trainer");
            Speler speler = new Speler("kwak", 20, team);
            //mng.VoegSpelerToe(speler);

            //mng.InitialiseerDatabank(@"C:\Users\davy\Documents\data\EFLeague\foot.csv");
            Speler sp = mng.SelecteerSpeler(1);
            Console.WriteLine(sp);
        }
    }
}
