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

var time = new JupiterTime(2, 20);
var timeIn1Hour = time.AddHours(1);

time.PrintTime();

Console.ReadLine();

public class JupiterTime
{

    public JupiterTime(int hours, int minutes)
    {
        int totalMinutes = hours * 60 + minutes;
        int totalHours = (totalMinutes - Minutes) / 60;
        Hours = totalHours % 10;
        Minutes = totalMinutes % 60;
    }

    public int Hours { get; set; }
    public int Minutes { get; set; }

    public int AddHours(int toAdd)
    {
        return Hours = Hours + toAdd;
    }

    public void PrintTime()
    {
        Console.WriteLine($"{Hours}:{Minutes}");
    }
}


/*
public class JupiterTime
{
    public JupiterTime(int hours, int minutes)
    {
        Hours = hours;
        Minutes = minutes;
    }

    public int Hours { get;  set; }
    public int Minutes { get; set; }


    /*
    public int Hours {
        get
        {
            return Hours;
        }
        set
        {
            if (value > 10)

                Hours = 2;
            else Hours = value;
            
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

                Minutes = 3;
            //Hours = Hours + 1;
            else Minutes = value;

        }
    }

    
    public void PrintTime()
    {
        Console.WriteLine($"{Hours}:{Minutes}");
    }
}
*/


