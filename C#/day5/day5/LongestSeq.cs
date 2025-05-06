namespace day5;

public class LongestSeq
{
    public static int[] sol(int[] arr)
    {

        if (arr.Length == 0) return arr;
        int cnt = 1;
        int prev = arr[0];
        int highest = 1;
        int highestnum = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == prev)
            {
                cnt++;
                if (cnt > highest)
                {
                    highest = cnt;
                    highestnum = arr[i];
                }
            }
            else
            {
                cnt = 1;
                prev = arr[i];
            }
        }
        int[] result = new int[highest];
        for (int j = 0; j < highest; j++)
        {
            result[j] = highestnum;
        }
        return result;
    }
}