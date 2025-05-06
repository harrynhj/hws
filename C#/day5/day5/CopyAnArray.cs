public class CopyAnArray
{
    public static void sol()
    {
        // Init Array
        int[] array = new int[10];
        for (int i = 0; i < 10; i++)
        {
            array[i] = i;
        }
        
        // second array
        int[] array2 = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            array2[i] = array[i];
            Console.WriteLine($"array1: {array[i]}, array2: {array2[i]}");
        }



    }
}