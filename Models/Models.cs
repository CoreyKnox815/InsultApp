namespace Insulter.Models;

public class Insult
{
    public int id {get; set;}
    public string insult {get; set;}

    public override string ToString()
    {
        return insult;
    }

}