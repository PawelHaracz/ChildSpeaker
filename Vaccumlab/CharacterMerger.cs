namespace Vaccumlab;
using System.Text;

/// <summary>
/// Class merge group of consecutive characters on the word,
/// when word ends on the consonants then remove consonants
/// </summary>
internal class CharacterMerger : ICharacterMerger
{
    public string Merge(string word)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < word.Length; i++)
        {
            if (Constants.Vowels.Contains(word[i]))
            {
                sb.Append(word[i]);
            }
            else
            {
                for (int j = i + 1; j < word.Length; j++)
                {
                    //skip all next Consonants
                    if (Constants.Vowels.Contains(word[j]))
                    {
                        sb.Append(word[i]);
                        i = j-1;
                        break;
                    }
                }
            }
        }
        
        return sb.ToString();
    }

    public string Process(string word)
    {
        throw new NotImplementedException();
    }
}