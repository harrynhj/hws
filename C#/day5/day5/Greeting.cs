namespace day5;

public class Greeting
{
    
    public static void sol()
    {
        DateTime localDate = DateTime.Now;
        if (localDate.Hour >=6 && localDate.Hour < 12)
        {
            Console.WriteLine("Good Morning");
        } else if (localDate.Hour >= 12 && localDate.Hour < 18)
        {
            Console.WriteLine("Good Afternoon");
        } else if (localDate.Hour >= 18 && localDate.Hour < 24)
        {
            Console.WriteLine("Good Evening");
        } else
        {
            Console.WriteLine("Good Night");
        }
    }
}