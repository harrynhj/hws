namespace day5;

public class ReverseString
{
    public static string sol1(string s)
    {
        // CharArrayWay
        char[] chars = s.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }

    public static void sol2(string s)
    {
        for (int i = s.Length - 1; i >= 0; i--)
        {
            Console.Write(s[i]);
        }
        Console.WriteLine();
    }
    
    
}