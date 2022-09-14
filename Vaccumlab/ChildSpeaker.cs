using System.Text;

public class ChildSpeaker
{
    private readonly char[] Vowels = new[] { 'a', 'e', 'i', 'o', 'u', 'y' };
    private readonly char[] Consonants = new[]
        { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };

    public string Process(string word)
    {
        var sb = new StringBuilder();
        var firstCharacter = word[0];
        if (Vowels.Contains(firstCharacter))
        {
            //vowels = logic
            for (int i = 1; i < word.Length; i++)
            {
                if (Consonants.Contains(word[i]))
                {
                    firstCharacter = word[i];
                    sb.Append(firstCharacter);
                    break;
                }
            }
        }
        
        //ignore first character
        for (int i = 0; i < word.Length; i++)
        {
            if (Consonants.Contains(word[i]))
            {
                sb.Append(firstCharacter);
            }
            else
            {
                sb.Append(word[i]);
            }
        }

        return sb.ToString();
    }
}