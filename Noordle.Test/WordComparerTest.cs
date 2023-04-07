using Noordle.Models;
using Noordle.Services.Implementations;

namespace Noordle.Test;

public class WordComparerTest
{
    [Test]
    public void EqualWords()
    {
        var word1 = "Appel";
        var word2 = "Appel";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);
        
        Assert.IsTrue(isMatch);
        Assert.IsTrue(comparison.Letters.All(c => c == LetterStatus.Correct));
    }
    
    [Test] 
    public void EqualWords_DifferentCasing() 
    { 
        var word1 = "Appel"; 
        var word2 = "APPEL"; 
 
        var isMatch = WordComparer.IsMatch(word1, word2); 
        var comparison = WordComparer.Compare(word1, word2); 
         
        Assert.IsTrue(isMatch); 
        Assert.IsTrue(comparison.Letters.All(c => c == LetterStatus.Correct));
    } 
    
    [Test]
    public void InequalWords()
    {
        var word1 = "Appel";
        var word2 = "Druif";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);
        
        Assert.IsFalse(isMatch);
        Assert.IsTrue(comparison.Letters.All(c => c == LetterStatus.Incorrect));
    }
    
    [Test]
    public void PartialEqualWords1()
    {
        var word1 = "Appel";
        var word2 = "Braam";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        TestHelper.AssertComparison(comparison, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.IncorrectLocation, LetterStatus.Incorrect, LetterStatus.Incorrect);
    }
    
    [Test]
    public void PartialEqualWords2()
    {
        var word1 = "Appel";
        var word2 = "Aardp";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        TestHelper.AssertComparison(comparison, LetterStatus.Correct, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.IncorrectLocation);
    }
    
    [Test]
    public void PartialEqualWords3()
    {
        var word1 = "Aardp";
        var word2 = "Appel";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        TestHelper.AssertComparison(comparison, LetterStatus.Correct, LetterStatus.IncorrectLocation, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.Incorrect);
    }
    
    [Test]
    public void PartialEqualWords4()
    {
        var word1 = "Braam";
        var word2 = "Aarde";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        TestHelper.AssertComparison(comparison, LetterStatus.IncorrectLocation, LetterStatus.IncorrectLocation, LetterStatus.IncorrectLocation, LetterStatus.Incorrect, LetterStatus.Incorrect);
    }
    
    [Test]
    public void PartialEqualWords5()
    {
        var word1 = "Radar";
        var word2 = "Aarde";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        TestHelper.AssertComparison(comparison, LetterStatus.IncorrectLocation, LetterStatus.Correct, LetterStatus.IncorrectLocation, LetterStatus.IncorrectLocation, LetterStatus.Incorrect);
    }
    
    [Test]
    public void PartialEqualWords6()
    {
        var word1 = "Aarde";
        var word2 = "Radar";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        TestHelper.AssertComparison(comparison, LetterStatus.IncorrectLocation, LetterStatus.Correct, LetterStatus.IncorrectLocation, LetterStatus.IncorrectLocation, LetterStatus.Incorrect);
    }
}