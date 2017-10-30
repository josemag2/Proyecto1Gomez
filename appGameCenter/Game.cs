using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Game
{






    private string name;

    public string Name
    {
        get { return name; }

    }
    private Genres genre;

    public Genres Genre
    {
        get { return genre; }
        set { genre = value; }
    }

    private List<Platforms> platforms;

    public List<Platforms> Platforms
    {
        get { return platforms; }

    }

    private int releaseDate;

    public int ReleaseDate
    {
        get { return releaseDate; }

    }
    private Dictionary<Platforms, Ranking> rankings;

    public Dictionary<Platforms, Ranking> Rankings
    {
        get { return rankings; }

    }




    public override bool Equals(object obj)
    {
        if (obj is Game)
        {
            Game aux = (Game)obj;
            return this.Name == aux.Name;
        }
        else
        {
            return false;
        }


    }
    public override string ToString()
    {
        string imp = string.Format("---- {0} - {1} - ", Name, ReleaseDate);
        int cont = 0;
        foreach (Platforms s in platforms)
        {
            cont++;
            imp += s;
            if (cont != platforms.Count)
            {
                imp += ", ";
            }

        }

        imp += string.Format(" - {0} -----", Genre);

        imp += "\n           Rankings:";
        foreach (Ranking rs in rankings.Values)
        {
            int result = 0;

            imp += "\n          -" + rs.Name;
            for (int x = 0; x <= rs.Scores.Count - 1; x++)
            {
                result += rs.Scores[x].Points;
            }
            imp += "(" + result + ")";

        }


        return imp;
    }
    //endregion
    public Game(string name, Genres genre, List<Platforms> platforms, int releaseDate, Dictionary<Platforms, Ranking> rankings)
    {
        this.name = name;
        this.genre = genre;
        this.platforms = platforms;
        this.releaseDate = releaseDate;
        this.rankings = rankings;

    }
    public Game(string data)
    {
        string[] splittedData = data.Split('-');
        this.name = splittedData[0];
        this.genre = (Genres)int.Parse(splittedData[1]);
        string[] splittedPlatforms = splittedData[2].Split(',');
        platforms = new List<Platforms>();
        foreach (string platString in splittedPlatforms)
        {
          /*  string[] splittedPlatform = platString.Split(':');
            string songName = splittedPlatforms[0];
            string authorName = splittedPlatforms[1];
            Song song = Musify.GetSongByNameAndAuthor(songName, authorName);
            songs.Add(song);*/
        }
    }

    
    
}

