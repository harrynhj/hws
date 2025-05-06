using System.Text;

namespace day5;

public class Pyramid
{
    public static void sol()
    {
        Console.WriteLine("input pyramid size: ");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++) {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < n-i-1; j++)
            {
                sb.Append(" ");
            }
            for (int k = 0; k < i*2+1; k++)
            {
                sb.Append("*");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}