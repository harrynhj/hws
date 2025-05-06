namespace day5;

public class PalindromesWord
{
    public static void sol(string s)
    {
        string[] splits = s.Split([' ', ',', '!', '?', '.'], StringSplitOptions.RemoveEmptyEntries);
        
        Console.WriteLine(string.Join(" ", splits));
        for (int i = 0; i < splits.Length; i++)
        {
            int j = 0;
            int k = splits[i].Length-1;
            bool res = true;
            while (j < k)
            {
                if (splits[i][j] != splits[i][k])
                {
                    res = false;
                    break;
                }
                j++;
                k--;
            }
            if (res) Console.WriteLine(splits[i]);
            
        }
    }
}