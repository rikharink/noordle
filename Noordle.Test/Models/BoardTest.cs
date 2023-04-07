using Noordle.Models;

namespace Noordle.Test.Models;

public class BoardTest
{
    [Test] 
    public void Board() 
    { 
        var bord = new Board("Appel", 5); 
 
        var result = bord.Guess("Aarde"); 
         
        Assert.That(result, Is.Not.Null); 
        TestHelper.AssertComparison(result, LetterStatus.Correct, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.IncorrectLocation);
    }
}