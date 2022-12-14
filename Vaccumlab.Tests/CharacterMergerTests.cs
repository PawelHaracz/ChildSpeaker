namespace Vaccumlab.Tests;
using Contracts;
using Implementations;
using Xunit;

public class CharacterMergerTests
{
    private readonly ICharacterMerger _merger = new CharacterMerger();

    private string Act(string word) => _merger.Merge(word);

    [Theory]
    [InlineData("mama", "mama")]
    [InlineData("mapa", "mapa")]
    [InlineData("obelisk", "obelis")]
    [InlineData("ababa", "ababa")]
    [InlineData("abcdefghijklmnopqrstuvwxyz", "abefijopuvyz")]
    public void word_does_not_have_any_group_of_consecutive_characters(string word, string expected)
    {
        var act = Act(word);
        Assert.Equal(expected, act); 
    }

    [Theory]
    [InlineData("abba", "aba")]
    [InlineData("abwrdta", "aba")]
    [InlineData("bdabwrdta", "baba")]
    [InlineData("bcdfghjklmnpqrstvwxz", "b")]
    public void word_contains_group_of_consecutive_consonants_should_be_merged(string word, string expected)
    {
        var act = Act(word);
        Assert.Equal(expected, act); 
    }
    
    [Theory]
    [InlineData("aaba", "aba")]
    [InlineData("bya", "ba")]
    [InlineData("naomi", "nomi")]
    [InlineData("aeiouy", "y")]
    public void word_contains_group_of_consecutive_should_be_merged_to_last_vowel(string word, string expected)
    {
        var act = Act(word);
        Assert.Equal(expected, act); 
    }
}