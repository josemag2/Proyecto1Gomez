using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Player
{
    private string nickName;

    public string NickName
    {
        get { return nickName; }
        set { nickName = value; }
    }
    private String email;

    public String Email
    {
        get { return email; }
        set { email = value; }
    }
    private Countries country;

    public Countries Country
    {
        get { return country; }
        set { country = value; }
    }


    public override string ToString()
    {
        return string.Format("{0} - {1} - {2}", NickName, Email, Country);
    }

    public override bool Equals(object obj)
    {
        if (obj is Player)
        {
            Player aux = (Player)obj;
            return this.NickName == aux.NickName;
        }
        else
        {
            return false;
        }


    }


    //endregion
    public Player(string nick, string email, Countries country)
    {
        this.nickName = nick;
        this.email = email;
        this.country = country;

    }
    public Player(string data)
    {
        string[] splittedData = data.Split('-');
        this.nickName = splittedData[0];
        this.email = splittedData[1];
        this.country = (Countries)int.Parse(splittedData[2]);


    }

    

}

