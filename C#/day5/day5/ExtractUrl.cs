namespace day5;

public class ExtractUrl
{
    public static void sol(string s)
    {
        string[] splits = s.Split("://");
        string protocol = "";
        string remainder = "";

        if (splits.Length == 1)
        {
            protocol = "";
            remainder = splits[0];
        }
        else
        {
            protocol = splits[0];
            remainder = splits[1];
        }

        string server = "";
        string resource = "";

        int slashIndex = remainder.IndexOf('/');
        if (slashIndex == -1)
        {
            server = remainder;
            resource = "";
        }
        else
        {
            server = remainder.Substring(0, slashIndex);
            resource = remainder.Substring(slashIndex + 1);
        }

        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
    }
}