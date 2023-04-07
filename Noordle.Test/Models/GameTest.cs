using Noordle.Models;

namespace Noordle.Test.Models;

public class GameTest
{
    private readonly List<string> _wordsToGuess = new List<string> 
    { 
        "Fruit", 
        "Appel", 
        "Braam", 
        "Druif" 
    }; 
     
    [Test] 
    public void Game() 
    { 
        var game = new Game(_wordsToGuess); 
 
        var result = game.GuessWord("Adieu"); 
         
        var fruitResult = result.Matches[0]; 
        TestHelper.AssertComparison(fruitResult, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.IncorrectLocation, LetterStatus.Incorrect, LetterStatus.IncorrectLocation); 
        var appelResult = result.Matches[1]; 
        TestHelper.AssertComparison(appelResult, LetterStatus.Correct, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.Correct, LetterStatus.Incorrect); 
        var braamResult = result.Matches[2]; 
        TestHelper.AssertComparison(braamResult, LetterStatus.IncorrectLocation, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.Incorrect, LetterStatus.Incorrect); 
        var druifResult = result.Matches[3]; 
        TestHelper.AssertComparison(druifResult, LetterStatus.Incorrect, LetterStatus.IncorrectLocation, LetterStatus.IncorrectLocation, LetterStatus.Incorrect, LetterStatus.IncorrectLocation);
    } 
     
    [Test] 
    public void Game_IfWordIsSolved_ThenGuessReturnsNull() 
    { 
        var game = new Game(_wordsToGuess); 
 
        game.GuessWord("Appel"); 
        var result = game.GuessWord("Adieu"); 
         
        Assert.That(result.Matches[1], Is.Null);
    }
    
    [Test] 
    public void Game_IfMaxGuessesReached_ThenGameOver() 
    { 
        var game = new Game(new []{"Appel"}); 
 
        game.GuessWord("Adieu"); 
        game.GuessWord("Adieu"); 
        game.GuessWord("Adieu"); 
        game.GuessWord("Adieu"); 
        game.GuessWord("Adieu"); 
        game.GuessWord("Adieu");

        var ex = Assert.Throws<InvalidOperationException>(() => game.GuessWord("Appel"));
        Assert.That(ex.Message, Is.EqualTo("Game over!"));
    }
    
    [Test] 
    public void Game_IfWordsOfDifferentLengths_ThenInvalid()
    {
        Assert.Throws<InvalidOperationException>(() => new Game(new[] { "Appel", "Peer", "Banaan" }));
    }
}