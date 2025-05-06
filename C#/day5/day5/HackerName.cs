using System.Text;

namespace day5;

public class HackerName
{
    public static void sol()
    {
        Console.WriteLine("Input your fav color: ");
        string? color = Console.ReadLine();
        Console.WriteLine("Input your astrology sign: ");
        string? sign = Console.ReadLine();
        Console.WriteLine("Input your street address number: ");
        string? num = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        sb.Append(color);
        sb.Append(sign);
        sb.Append(num);
        Console.WriteLine($"your hacker name is {sb.ToString()}");
    }
}