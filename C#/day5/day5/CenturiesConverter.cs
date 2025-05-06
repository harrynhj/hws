namespace day5;

public class CenturiesConverter
{
    public static void sol()
    {
        System.Console.WriteLine("Input a number: ");
        int? centuries = System.Convert.ToInt32(Console.ReadLine());
        int years = centuries.Value * 100;
        int days = years * 365;
        int hours = days * 24;
        int minutes = hours * 60;
        long seconds = minutes * 60;
        long milliseconds = seconds * 1000;
        long microseconds = milliseconds * 1000;
        long nanoseconds = microseconds * 1000;
        System.Console.WriteLine($"{centuries.Value} centuries = {years} years = {days} days = " +
                                 $"{hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} " +
                                 $"milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
}