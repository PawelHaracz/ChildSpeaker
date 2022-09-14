using System.Text;
using Vaccumlab.Contracts;

namespace Vaccumlab.Implementations;

/// <summary>
/// Class merge group of consecutive characters on the word,
/// A group of consecutive consonants should be merged to the first single consonant
/// A group of consecutive vowels should be merged to the last single vowel
/// </summary>
internal class CharacterMerger : ICharacterMerger
{
    
    public string Merge(string word)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < word.Length; i++)
        {
            var character = word[i];
            for (int j = i + 1; j < word.Length; j++)
            {
                var nextCharacter = word[j];
                var currentCharacter = word[i];
                
                if (Constants.Vowels.Contains(currentCharacter) && Constants.Vowels.Contains(nextCharacter))
                { 
                    character = nextCharacter;
                    i = j;
                }
                else if (Constants.Consonants.Contains(currentCharacter) && Constants.Consonants.Contains(nextCharacter))
                {
                    i = j;
                }
                else
                {
                    break;
                }
            }
            
            sb.Append(character);
        }

        return sb.ToString();
    }
}