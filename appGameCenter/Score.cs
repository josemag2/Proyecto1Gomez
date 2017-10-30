using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Score
{
    private string nickName;

    public string NickName
    {
        get { return nickName; }

    }
    private int points;

    public int Points
    {
        get { return points; }
        set { points = value >= 0 ? value : 0; }
    }

    public override string ToString()
    {
        return string.Format("{0} - {1} ", NickName, Points ); 
    }

    public Score(string nick, int points)
    {
        this.nickName = nick;
        this.points = points>= 0 ? points : 0;
    }
}

