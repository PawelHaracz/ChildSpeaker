namespace Vaccumlab.Tests;
using Xunit;
using Contracts;
using Implementations;

public class ChildSpeakerTests
{
    private readonly IChildSpeaker _childSpeak = new ChildSpeaker();
    private string Act(string word) => _childSpeak.Process(word);

    [Theory]
    [InlineData("mapa", "mama")]
    [InlineData("nudes", "nune")]
    [InlineData("nook", "no")]
    public void uses_exactly_one_unique_consonant_in_the_word(string word, string expected)
    {
        var act = Act(word);
        Assert.Equal(expected, act);
    }

    [Theory]
    [InlineData("alibaba", "lalilala")]
    [InlineData("obese", "bobebe")]
    public void words_starts_with_a_vowel_should_add_first_consonant_to_beginning(string word, string expected)
    {
        var act = Act(word);
        Assert.Equal(expected, act);
    }

    [Theory]
    [InlineData("grater", "gage")]
    [InlineData("lajdak", "lala")]
    [InlineData("lampa", "lala")]
    [InlineData("bratislava", "babibaba")]
    [InlineData("ahoj", "haho")]
    [InlineData("ahojo", "hahoho")]
    public void group_of_consecutive_consonants_should_be_replaced_as_one_consonants_and_the_remove_last_consonants(string word, string expected)
    {
        var act = Act(word);
        Assert.Equal(expected, act);   
    }
    
    [Theory]
    [InlineData("naomi", "noni")]
    [InlineData("aikido", "kikiko")]
    [InlineData("ahojoo", "hahoho")]
    public void group_of_consecutive_vowels_should_be_replaced_as_one_last_vowel(string word, string expected)
    {
        var act = Act(word);
        Assert.Equal(expected, act);   
    }
}