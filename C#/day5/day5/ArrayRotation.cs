namespace day5;

public class ArrayRotation
{
    public static int[] sol(int[] arr, int k)
    {
        int[] res = new int[arr.Length];
        for (int i = 1; i <= k; i++)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                int newpos = (j + i) % arr.Length;
                res[newpos] += arr[j];
            }
        }
        return res;
    }
}