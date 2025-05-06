namespace day5;

public class NumGuesser
{
    public static void sol()
    {
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("Guess a number between 1 and 3: ");
        string guess = "";
        while (guess != null)
        {
            guess = Console.ReadLine();
            int num = Convert.ToInt32(guess);
            if (num == correctNumber) {
                Console.WriteLine("Correct");
                break;
            } else
            {
                Console.WriteLine("Incorrect");
            }

        }
        
    }
}