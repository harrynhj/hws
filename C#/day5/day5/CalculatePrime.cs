namespace day5;

public class CalculatePrime
{
    static public int[] FindPrimesInRange(int startNum, int endNum) 
    {
        int[] result = new int[endNum - startNum + 1];
        int resCount = 0;
        for (int i = startNum; i <= endNum; i++)
        {
            int cnt = 0;
            for (int j = 1; j <= i; j++)
            {
                if (i % j == 0)
                {
                    cnt++;
                }
            }

            if (cnt == 2)
            {
                result[resCount] = i;
                resCount++;
            }
        }
        return result;
    }
}