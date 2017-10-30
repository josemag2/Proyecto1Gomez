using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appGameCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("p1", "pepe@hotmail.es", Countries.Australia);
            Player p2 = new Player("p2", "jjp@hotmail.es", Countries.Brazil);
            Player p3 = new Player("p3", "pepe@hotmail.es", Countries.Canada);
            Player p4 = new Player("p4", "jjp@hotmail.es", Countries.France);
            Player p5 = new Player("p5", "pepe@hotmail.es", Countries.Japan);
            Player p6 = new Player("p6", "jjp@hotmail.es", Countries.Spain);
            GameServices.AddPlayer(p1);
            GameServices.AddPlayer(p2);
            GameServices.AddPlayer(p3);
            GameServices.AddPlayer(p4);
            GameServices.AddPlayer(p5);
            GameServices.AddPlayer(p6);

            //tiros a puerta
            Score s1 = new Score("p1", 5);
            Score s2 = new Score("p2", 1);
            Score s3 = new Score("p3", 3);
            // faltas
            Score s4 = new Score("p4", 4);
            Score s5 = new Score("p5", 3);
            Score s6 = new Score("p3", 7);
            //

            // Listas con los puntos

            List<Score> scoresT = new List<Score> { s1, s2, s3 };
            List<Score> scoresF = new List<Score> { s6 };
            List<Score> scoresT2 = new List<Score> { s1 };
            List<Score> scoresF2 = new List<Score> { s4 };
            List<Score> scoresT3 = new List<Score> { s5 };
            List<Score> scoresF3 = new List<Score> { s5 };


            Ranking rT = new Ranking("Tiros a puerta", scoresT);
            Ranking rF = new Ranking("Faltas", scoresF);
            Ranking rT2 = new Ranking("Faltas", scoresF);
            Ranking rF2 = new Ranking("Faltas", scoresF);
            Ranking rT3 = new Ranking("Faltas", scoresF);
            Ranking rF3 = new Ranking("Faltas", scoresF);

            Dictionary<Platforms, Ranking> rankingsF = new Dictionary<Platforms, Ranking>();
            Dictionary<Platforms, Ranking> rankingsNB = new Dictionary<Platforms, Ranking>();
            Dictionary<Platforms, Ranking> rankingsNH = new Dictionary<Platforms, Ranking>();

            rankingsF.Add(Platforms.PS4, rT);

            rankingsF.Add(Platforms.MAC, rF);

            rankingsNB.Add(Platforms.PC, rT2);
            rankingsNB.Add(Platforms.PS4, rF2);
            

            rankingsNH.Add(Platforms.PS4, rT3);
            rankingsNH.Add(Platforms.MAC, rF3);
            rankingsNH.Add(Platforms.Linux, rF3);

            List<Platforms> platf1 = new List<Platforms>() { Platforms.MAC, Platforms.PS4 };
            List<Platforms> platf2 = new List<Platforms>() { Platforms.PC, Platforms.PS4, Platforms.XBOXONE };
            List<Platforms> platf3 = new List<Platforms>() { Platforms.MAC, Platforms.PS4, Platforms.Linux };
            Game g1 = new Game("Fifa", Genres.Simulation, platf1, 2015, rankingsF);
            Game g2 = new Game("Nba", Genres.Simulation, platf2, 2000, rankingsNB);
            Game g3 = new Game("NHL", Genres.Adventure, platf3, 2005, rankingsNH);
            Console.WriteLine(g3);
            GameServices.AddGames(g1);
            GameServices.AddGames(g2);
            GameServices.AddGames(g3);
            //   GameServices.AddAll();




            // Console.WriteLine(GameServices.OldestGame());
            // Console.WriteLine("Simulacion: "+ GameServices.GameCountByGenre(Genres.Adventure));
            // Console.WriteLine(GameServices.GameSearch("F"));

            //  GameServices.TotalPoints("Fifa", "Faltas");

            //  Console.WriteLine(GameServices.MaxPonits()); 

            /* Console.WriteLine("Introduce un Jugador");
             string j = Console.ReadLine();
             GameServices.PlayerGames(j);*/
            GameServices.GamesByPlayer();
           // GameServices.StarComando();
            Console.ReadLine();
            //Parte para el Export
            // GameServices.Export();
            //Console.WriteLine(s1.ToString());

            //

        }
    }
}
