namespace day5;

public class FizzBuzz
{
    public static void sol()
    {
        for (int i = 0; i < 100; i++)
        {
            if (i % 3  == 0 && i % 5 == 0) {
                Console.WriteLine("FizzBuzz");
            } else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            } else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }

        }
    }
}