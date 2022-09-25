// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


/* works!
var time = new JupiterTime();
time.Hours = 8;
time.Minutes = 40;

//Console.WriteLine(time.PrintTime);

PrintTime(time);
//time.PrintTime();

void PrintTime(JupiterTime time)
{
    Console.WriteLine($"{time.Hours}:{time.Minutes}");
}


Console.ReadLine();

public class JupiterTime
{
    public int Hours
    {
        set;
        get;
    }
    public int Minutes
    {
        set;
        get;
    }

    /*
    public void PrintTime()
    {
        Console.WriteLine($"{Hours}:{Minutes}");
    }
}
    */

var time = new JupiterTime(14, 88);

time.PrintTime();

Console.ReadLine();


public class JupiterTime
{
    public JupiterTime(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }
    public int Hours {
        get
        {
            return Hours;
        }
        set
        {
            if (value > 10)
            
                Hours = value - 10;
            
        }
    }
    public int Minutes
    {
        get
        {
            return Minutes;
        }
        set
        {
            if (value >= 60)

                Minutes = value - 60;
            //Hours = Hours + 1;

        }
    }

    public void PrintTime()
    {
        Console.WriteLine($"{Hours}:{Minutes}");
    }
}


