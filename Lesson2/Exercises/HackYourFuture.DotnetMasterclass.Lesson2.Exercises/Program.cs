// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



var time = new JupiterTime(1, 21);
//var timeIn1Hour = time.ChangeHours(-888);
var timeIn20Minutes = time.ChangeMinutes(-739);


//time.PrintTime(); <-- old print method, works

Console.WriteLine(time);
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

    public int ChangeHours(int toChange)
    {
        if (toChange < 0)
        {
            if (Hours + toChange < 0)
            {
                return Hours = (10 + (Hours + (toChange%10))) % 10;
            }
            else return Hours = (Hours + toChange) % 10;
        }else 
        return Hours = (Hours + toChange)%10;
    }
    
    public int ChangeMinutes(int toChange)
    {
        int totalMinutes = Hours * 60 + Minutes;
        int newTotalMinutes = totalMinutes + toChange%60;
        int newMinutes = newTotalMinutes % 60;
        int newHours = (toChange - toChange % 60) / 60;
        if (Minutes+ toChange % 60 >= 60)
        {
            ChangeHours(newHours +1 );

        }
        else if (Minutes + toChange % 60 < 0 && toChange < 0) {
            ChangeHours(newHours - 1);
        }
        else
        {
            ChangeHours(newHours);
        }
        return Minutes = newMinutes;
    }
    public override string ToString()
    {
        if (Minutes < 10)
        { var toPrint = $"0{Hours}:0{Minutes}";
            return toPrint;
        }
        else
        {
            var toPrint = $"0{Hours}:{Minutes}";
            return toPrint;
        }
         
    }

    /*
    old print method, works

    public void PrintTime()
    {
        if (Minutes < 10) {
            Console.WriteLine($"0{Hours}:0{Minutes}");
        }
        else Console.WriteLine($"0{Hours}:{Minutes}");
    }
    */
}


/* part 1 works!
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

/* 
  solution 2 works!
 
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


