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
                if (Constants.Consonants.Contains(currentCharacter) && Constants.Consonants.Contains(nextCharacter))
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
    
    // public string Merge(string word)
    // {
    //     var sb = new StringBuilder();
    //
    //     for (int i = 0; i < word.Length; i++)
    //     {
    //         if (Constants.Vowels.Contains(word[i]))
    //         {
    //             var vowel = word[i];
    //             for (int j = i + 1; j < word.Length; j++)
    //             {
    //                 if (Constants.Vowels.Contains(word[j]))
    //                 { 
    //                     vowel = word[j];
    //                     i = j;
    //                     break;
    //                 }
    //                 
    //             }
    //             sb.Append(vowel);
    //         }
    //         else
    //         {
    //             for (int j = i + 1; j < word.Length; j++)
    //             {
    //                 //skip all next Consonants
    //                 if (Constants.Vowels.Contains(word[j]))
    //                 {
    //                     sb.Append(word[i]);
    //                     i = j-1;
    //                     break;
    //                 }
    //             }
    //         }
    //     }
    //
    //     // var lastCharacters = word.Last();
    //     // if (Constants.Vowels.Contains(lastCharacters))
    //     // {
    //     //     sb.Append(lastCharacters);
    //     // }
    //     //
    //     return sb.ToString();
    // }
}