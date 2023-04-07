using Noordle.Models;

namespace Noordle.Test;

internal static class TestHelper
{
    internal static void AssertComparison(WordMatch comparison, params LetterStatus[] matches) 
    { 
        Assert.Multiple(() => 
        { 
            Assert.That(comparison.Letters[0], Is.EqualTo(matches[0])); 
            Assert.That(comparison.Letters[1], Is.EqualTo(matches[1])); 
            Assert.That(comparison.Letters[2], Is.EqualTo(matches[2])); 
            Assert.That(comparison.Letters[3], Is.EqualTo(matches[3])); 
            Assert.That(comparison.Letters[4], Is.EqualTo(matches[4])); 
        }); 
    } 
}