// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var time = new JupiterTime();
time.Hours = 8;
time.Minutes = 40;

//Console.WriteLine(time.PrintTime);

PrintTime(time);


void PrintTime(JupiterTime time)
{
    Console.WriteLine(time.Hours);
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
        Console.WriteLine(Hours);
    }
    */
}
