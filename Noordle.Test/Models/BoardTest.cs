using Noordle.Models;

namespace Noordle.Test.Models;

public class BoardTest
{
    [Test] 
    public void Board() 
    { 
        var bord = new Board("Appel"); 
 
        var result = bord.Guess("Aarde"); 
         
        Assert.That(result, Is.Not.Null); 
        TestHelper.AssertComparison(result, LetterStatus.Correct, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.IncorrectLocation);
    }
    
    [Test] 
    public void Board_IfWon_ThenReturnNull() 
    { 
        var bord = new Board("Appel"); 
 
        bord.Guess("Appel"); 
        var result = bord.Guess("Braam"); 
         
        Assert.That(result, Is.Null);
    }
}