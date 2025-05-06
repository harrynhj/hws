namespace day5;

public class ByteForLoop
{
    public static void sol()
    {
        // It will cause infinity loop because type byte range is 0-255, unable to reach 500
        // Original Code
        // int max = 500;
        // for (byte i = 0; i < max; i++)
        // {
        //     Console.WriteLine(i);
        // }
        
        int max = 500;
        if (max > byte.MaxValue)
        {
            Console.WriteLine("Warning");
        }
        for (byte i = 0; i < max; i++)
        {
            Console.WriteLine(i);
            if (i == 255)
            {
                break;
            }
        }
    }
}