namespace day5;

public class ReverseWords
{
    public static string sol(string s)
    {
        char[] separators = { '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };
        HashSet<char> sepSet = new HashSet<char>(separators);
        
        List<string> tokens = new List<string>();
        string current = "";
        bool isWord = !sepSet.Contains(s[0]);
        foreach (char c in s)
        {
            if (sepSet.Contains(c))
            {
                if (isWord)
                {
                    tokens.Add(current);
                    current = "";
                }
                current += c;
                isWord = false;
            }
            else
            {
                if (!isWord)
                {
                    tokens.Add(current);
                    current = "";
                }
                current += c;
                isWord = true;
            }
        }
        if (current.Length > 0)
            tokens.Add(current);

        List<string> words = new List<string>();
        foreach (string t in tokens)
        {
            if (t.Length > 0 && !sepSet.Contains(t[0]))
                words.Add(t);
        }
        words.Reverse();
        
        int wordIndex = 0;
        for (int i = 0; i < tokens.Count; i++)
        {
            if (tokens[i].Length > 0 && !sepSet.Contains(tokens[i][0]))
            {
                tokens[i] = words[wordIndex++];
            }
        }
        return string.Join("", tokens);
    }

    
    
}