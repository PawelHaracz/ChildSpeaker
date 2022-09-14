namespace Vaccumlab.Tests;
using Xunit;

public class ChildSpeakerTests
{
    [Theory]
    [InlineData("mapa", "mama")]
    [InlineData("nudes", "nunen")]
    [InlineData("nook", "noon")]
    //[InlineData("grater", "gageg")]
   
    //[InlineData("lajdak", "lala")]
    //[InlineData("lampa", "lala")]
    public void uses_exactly_one_unique_consonant_in_the_word(string word, string expected)
    {
        var childSpeak = new ChildSpeaker();

        var act = childSpeak.Process(word);

        Assert.Equal(expected, act);
    }

    [Theory]
    [InlineData("alibaba", "lalilala")]
    public void words_starts_with_a_vowel_should_add_first_consonant_to_beginning(string word, string expected)
    {
        
    }
}