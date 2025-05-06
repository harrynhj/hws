namespace day5;

public class FreqNums
{
    public static int sol(int[] arr)
    {
        int n = arr.Length;

        int[] unique = new int[n];
        int[] counts = new int[n];
        int uniqueCount = 0;

        for (int i = 0; i < n; i++)
        {
            int index = -1;
            for (int j = 0; j < uniqueCount; j++)
            {
                if (unique[j] == arr[i])
                {
                    index = j;
                    break;
                }
            }
            if (index == -1)
            {
                unique[uniqueCount] = arr[i];
                counts[uniqueCount] = 1;
                uniqueCount++;
            }
            else
            {
                counts[index]++;
            }
        }

        int maxCount = counts[0];
        int result = unique[0];
        for (int i = 1; i < uniqueCount; i++)
        {
            if (counts[i] > maxCount)
            {
                maxCount = counts[i];
                result = unique[i];
            }
        }
        return result;
    }
}