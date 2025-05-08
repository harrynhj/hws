namespace day6;

public class ReverseArray
{
    static int[] GenerateNumbers()
    {
        Random rnd = new Random();
        int[] numbers = new int[10];
        for (int i = 0; i < 10; i++)
        {
            int num  = rnd.Next(1, 100);
            numbers[i] = num;
        }
        return numbers;
    }

    static void PrintNumbers(int[] numbers)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();
    }

    static void Reverse(int[] numbers)
    {
        int i = 0;
        int j = numbers.Length - 1;
        while (i < j)
        {
            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
            i++;
            j--;
        }

    }

    public static void Main(string[] args) {
        int[] numbers = GenerateNumbers();
        Console.WriteLine("Before Reverse:");
        PrintNumbers(numbers);
        Reverse(numbers);
        Console.WriteLine("After Reverse:");
        PrintNumbers(numbers);
    }
}