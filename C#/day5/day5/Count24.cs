using System.Text;

namespace day5;

public class Count24
{
    public static void sol()
    {
        for (int i = 1; i <= 4; i++)
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j <= 24; j += i)
            {
                sb.Append(j);
                sb.Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}