using System.Text;
using Vaccumlab.Contracts;

namespace Vaccumlab.Implementations;

internal class ChildSpeaker : IChildSpeaker
{
    private readonly CharacterMerger _merger;

    public ChildSpeaker()
    {
        _merger = new CharacterMerger();
    }

    public string Process(string word)
    {
        word = _merger.Merge(word);
        var sb = new StringBuilder();
        var firstCharacter = word[0];
        if (Constants.Vowels.Contains(firstCharacter))
        {
            //vowels = logic
            for (int i = 1; i < word.Length; i++)
            {
                if (Constants.Consonants.Contains(word[i]))
                {
                    firstCharacter = word[i];
                    sb.Append(firstCharacter);
                    break;
                }
            }
        }

        foreach (var @char in word)
        {
            sb.Append(Constants.Consonants.Contains(@char) ? firstCharacter : @char);
        }

        return sb.ToString();
    }


}