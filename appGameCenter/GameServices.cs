using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;


public static class GameServices
{

    const string PATH = "../../Resources/data.txt";
    private static List<Player> players = new List<Player>();

    public static List<Player> Players
    {
        get { return players; }
        set { players = value; }

    }


    private static List<Game> games = new List<Game>();

    public static List<Game> Games
    {
        get { return games; }
        set { games = value; }
    }

    public static void Export()

    {


        // Convertir todas las canciones en string con el formato
        string playerData = ConvertPlayer();
        // Convertir todas las playlists en string con el formato
        string gameData = ConvertGame();
        // Escribir en el fichero los datos anteriores separados por el patron '*+++*'
        try
        {
            StreamWriter file = File.CreateText(PATH);
            string completeData = playerData + "*+*+*+*\n" + gameData;
            file.Write(completeData);
            file.Close();
            Console.WriteLine("Datos exportados correctamente");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al exportar los datos. " + e);
        }

    }
    public static string ConvertPlayer()
    {
        string playersData = "";
        foreach (Player p in Players)
        {

            //songData = song.Name + "-" + song.Author + "-" + song.Duration + "-" + song.Year + "-" + song.Genre + "-" + song.Score;
            playersData += string.Format("{0}-{1}-{2}", p.NickName, p.Email, p.Country);
            playersData += "\n";

        }
        return playersData;
    }
    public static string ConvertGame()
    {
        List<Ranking> rr = new List<Ranking>();
        string gameData = "";
        foreach (Game g in Games)
        {
            int cont = 0;

            //songData = song.Name + "-" + song.Author + "-" + song.Duration + "-" + song.Year + "-" + song.Genre + "-" + song.Score;
            gameData += string.Format("{0}-{1}-{2}-", g.Name, g.Genre, g.ReleaseDate);
            foreach (Platforms p in g.Platforms)
            {
                cont++;
                gameData += p;
                if (cont != g.Platforms.Count)
                {
                    gameData += ",";
                }

            }
            gameData += "\n";


        }


        foreach (Game g in Games)
        {


            gameData += "\n*+*+*+*\n";
            foreach (Ranking rs in g.Rankings.Values)
            {
                

                gameData += string.Format("{0}-{1}-", g.Name, rs.Name);

                for (int x = 0; x <= rs.Scores.Count - 1; x++)
                {
                    gameData += string.Format("{0}={1},", rs.Scores[x].NickName, rs.Scores[x].Points);
                    
                }

                gameData += "\n";
            }

        }



        return gameData;

    }

    public static void Import()
    {
        List<string> lines = ReadFile(PATH);

        List<string> playerLines = new List<string>();
        List<string> gameLines = new List<string>();
        bool isGame = false;
        foreach (string line in lines)
        {
            if (line == "*+++*")
            {
                isGame = true;
            }
            else
            {
                if (!isGame)
                {
                    playerLines.Add(line);
                }
                else
                {
                    gameLines.Add(line);
                }
            }
        }
        Players = new List<Player>();
        Games = new List<Game>();
        foreach (string line in playerLines)
        {
            Player s = new Player(line);
            Players.Add(s);


        }
        foreach (string line in gameLines)
        {
            Game l = new Game(line);
            Games.Add(l);
        }
    }


    private static List<string> ReadFile(string path)
    {
        List<string> lines = new List<string>();
        try
        {
            StreamReader file = File.OpenText(path);
            string line = "";
            while (line != null)
            {
                line = file.ReadLine();
                if (line != null)
                {
                    lines.Add(line);
                }
            }
            file.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al leer fichero\n" + e);
        }
        return lines;
    }

    public static Game OldestGame()
    {
        Game oldestGame = null;
        int year = int.MaxValue;
        foreach (Game game in Games)
        {
            int y = game.ReleaseDate;
            if (year > y)
            {
                oldestGame = game;
                year = y;
            }
        }

        Console.WriteLine(oldestGame);
        return oldestGame;
    }
    public static Game MaxPonits()
    {
        int t= 0;
        Game maxPoints = null;
        int max = int.MaxValue;
        foreach (Game game in Games)
        {
            foreach (Ranking r in game.Rankings.Values)
            {          
                    for (int x = 0; x <= r.Scores.Count - 1; x++)
                    {
                        t += r.Scores[x].Points;
                    }
              
                if (max > t)
                {
                    maxPoints = game;
                    max = t;
                }
            }


            
        }
        return maxPoints;
    }
    public static void PlayerGames(string player) {

        foreach (Game g in Games)
        {
                foreach (Ranking r in g.Rankings.Values)
                {
                        for (int x = 0; x <= r.Scores.Count - 1; x++)
                        {
                    if (player == r.Scores[x].NickName) {
                        Console.WriteLine(g);
                    }
                        }

                }
            
        }


    }
    public static void GamesByPlayer()
    {
        string player = "";
        foreach (Game g in Games)
        {
            foreach (Ranking r in g.Rankings.Values)
            {
                player = "";
                for (int x = 0; x <= r.Scores.Count - 1; x++)
                {
                    if (player != r.Scores[x].NickName)
                    {
                        player = r.Scores[x].NickName;
                        Console.WriteLine(player+" :   \n");
                        Console.WriteLine(g);
                    }
                }

            }

        }


    }
    public static int GameCountByGenre(Genres genre)
    {

        int count = 0;
        foreach (Game game in Games)
        {
            if (game.Genre == genre)
            {
                count++;
            }
        }
        Console.WriteLine(" Hay "+count+" con este Genero");
        return count;
    }
    public static string GameSearch(string obj)
    {

        foreach (Game game in Games)
        {
            if (game.Name.Contains(obj))
            {

                obj = game.Name;

            }

        }
        return obj;
    }
    public static void TotalPoints(string nGame, string fRankings) {
        int t =0;
        foreach (Game g in Games)
        {
            if (g.Name == nGame)
            {
                foreach (Ranking r in g.Rankings.Values) {
                    if (r.Name == fRankings) {
                      
                        for (int x = 0; x <= r.Scores.Count-1; x++) {
                            t += r.Scores[x].Points;
                        }
                        Console.WriteLine(string.Format("   {0} -- {1}: {2} ", nGame, fRankings, t));
                        break;
                    }


                }
            }

        }
    }
    

    // añadimos jugadores
    public static void AddPlayer(Player p)
    {
        Players.Add(p);
    

    }
    public static void AddGames(Game g)
    {
        Games.Add(g);

    }

    public static void StarComando()
    {
        

        while (true)
        {
            Console.WriteLine("Introduce un comando");
            string comando = Console.ReadLine();
            

            switch (comando)
            {
                case "import":
                    
                    break;
                case "export":
                    Export();
                    break;
                case "oldest":

                    OldestGame();

                    break;
                case "scoreCount":
                     Console.WriteLine("introduce nombre de juego");
                    string name = Console.ReadLine();
                    Console.WriteLine("introduce el Ranking(Ejem. Falta)");
                    string rank = Console.ReadLine();
                    TotalPoints(name, rank);
                    break;
                case "gamesCountByGenre":
                    Console.WriteLine("introduce un Genero");
                    string gen = Console.ReadLine();
                    Genres genr =  (Genres)Enum.Parse(typeof(Genres), gen, true);
                    GameCountByGenre(genr);
                    break;
                case "gamesByPlayer":
                    
                    break;
                default:
                    break;
            }
        }
    }



}

