using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Ranking
{
    int cont = 1;
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private List<Score> scores;

    public List<Score> Scores
    {
        get { return scores; }
       
    }

    public Ranking(string name, List<Score> scores)
    {
        this.name = name;
        this.scores = scores;
    }
    
    public override string ToString()
    {
        string imp = "";
        
        foreach (Score scor in Scores)
        {   imp += cont++ +". ";
            imp += string.Format("{0} ", scor);
            imp += "\n";
        }
        return imp; 
    }


}

