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
        Assert.IsTrue(comparison.All(c => c == "Green"));
    }
    
    [Test]
    public void InequalWords()
    {
        var word1 = "Appel";
        var word2 = "Druif";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);
        
        Assert.IsFalse(isMatch);
        Assert.IsTrue(comparison.All(c => c == "Red"));
    }
    
    [Test]
    public void PartialEqualWords1()
    {
        var word1 = "Appel";
        var word2 = "Braam";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        Assert.That(comparison[0], Is.EqualTo("Red"));
        Assert.That(comparison[1], Is.EqualTo("Red"));
        Assert.That(comparison[2], Is.EqualTo("Yellow"));
        Assert.That(comparison[3], Is.EqualTo("Red"));
        Assert.That(comparison[4], Is.EqualTo("Red"));
    }
    
    [Test]
    public void PartialEqualWords2()
    {
        var word1 = "Appel";
        var word2 = "Aardp";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        Assert.That(comparison[0], Is.EqualTo("Green"));
        Assert.That(comparison[1], Is.EqualTo("Red"));
        Assert.That(comparison[2], Is.EqualTo("Red"));
        Assert.That(comparison[3], Is.EqualTo("Red"));
        Assert.That(comparison[4], Is.EqualTo("Yellow"));
    }
    
    [Test]
    public void PartialEqualWords3()
    {
        var word1 = "Aardp";
        var word2 = "Appel";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        Assert.That(comparison[0], Is.EqualTo("Green"));
        Assert.That(comparison[1], Is.EqualTo("Yellow"));
        Assert.That(comparison[2], Is.EqualTo("Red"));
        Assert.That(comparison[3], Is.EqualTo("Red"));
        Assert.That(comparison[4], Is.EqualTo("Red"));
    }
    
    [Test]
    public void PartialEqualWords4()
    {
        var word1 = "Braam";
        var word2 = "Aarde";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        Assert.That(comparison[0], Is.EqualTo("Yellow"));
        Assert.That(comparison[1], Is.EqualTo("Yellow"));
        Assert.That(comparison[2], Is.EqualTo("Yellow"));
        Assert.That(comparison[3], Is.EqualTo("Red"));
        Assert.That(comparison[4], Is.EqualTo("Red"));
    }
    
    [Test]
    public void PartialEqualWords5()
    {
        var word1 = "Radar";
        var word2 = "Aarde";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        Assert.That(comparison[0], Is.EqualTo("Yellow"));
        Assert.That(comparison[1], Is.EqualTo("Green"));
        Assert.That(comparison[2], Is.EqualTo("Yellow"));
        Assert.That(comparison[3], Is.EqualTo("Yellow"));
        Assert.That(comparison[4], Is.EqualTo("Red"));
    }
    
    [Test]
    public void PartialEqualWords6()
    {
        var word1 = "Aarde";
        var word2 = "Radar";

        var isMatch = WordComparer.IsMatch(word1, word2);
        var comparison = WordComparer.Compare(word1, word2);

        Assert.IsFalse(isMatch);
        Assert.That(comparison[0], Is.EqualTo("Yellow")); 
        Assert.That(comparison[1], Is.EqualTo("Green"));
        Assert.That(comparison[2], Is.EqualTo("Yellow"));
        Assert.That(comparison[3], Is.EqualTo("Yellow"));
        Assert.That(comparison[4], Is.EqualTo("Red"));
    }
}

public static class WordComparer
{
    public static bool IsMatch(string wordA, string wordB) => wordA == wordB;

    public static List<string> Compare(string word, string guess)
    {
        var wordLetters = word.ToLower().ToCharArray();
        var guessLetters = guess.ToLower().ToCharArray();
        var matches = new List<string>(guess.Length);

        var matchedLetters = new List<char>();

        for (var i = 0; i < guessLetters.Length; i++)
        {
            var guessLetter = guessLetters[i];

            var matchesCount = matchedLetters.Count(l => l == guessLetter);
            var wordCount = word.ToLower().Count(l => l == guessLetter);

            if (wordLetters[i] == guessLetter)
            {
                matches.Add("Green");
                matchedLetters.Add(guessLetter);
            }
            else if (wordLetters.Contains(guessLetter) && (!matchedLetters.Contains(guessLetter) ||
                                                           matchesCount < wordCount))
            {
                matches.Add("Yellow");
                matchedLetters.Add(guessLetter);
            }
            else
            {
                matches.Add("Red");
            }
        }

        return matches;
    }
}