using Moq;
using Noordle.Models;
using Noordle.Services;
using Noordle.Services.Implementations;

namespace Noordle.Test.Services;

public class GameServiceTest
{
    private GameService _gameService;
    private Mock<IGameRepository> _gameRepositoryMock;
    private Mock<IWordlistRepository> _wordlistRepositoryMock;

    [SetUp]
    public void Setup()
    {
        _gameRepositoryMock = new Mock<IGameRepository>();
        _wordlistRepositoryMock = new Mock<IWordlistRepository>();
        _gameService = new GameService(
            _gameRepositoryMock.Object,
            _wordlistRepositoryMock.Object);
        
        SetupMocks();
    }

    private void SetupMocks()
    {
        _wordlistRepositoryMock.Setup(m => m.GetWordsOfLength(5))
            .Returns(new List<string>
            {
                "Aarde",
                "Appel",
                "Boter",
                "Braam",
                "Druif",
                "Dader"
            });
    }

    [Test]
    public async Task StartGame()
    {
        var response = await _gameService.StartGame(2, 5);

        _gameRepositoryMock.Verify(m =>
            m.AddOrUpdate(It.Is<Game>(g => g.Id == response.GameId && g.Boards.Count == 2 && g.WordLength == 5)));
    }
    
    [Test]
    public void GuessWord_IfGameNotExists_ThenException()
    {
        var gameId = Guid.NewGuid();
        var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _gameService.GuessWord(gameId, "Adieu"));
        Assert.That(ex.Message, Is.EqualTo($"Game with id {gameId} does not exist"));
    }
    
    [Test]
    public void GuessWord_IfGuessIsTooLong_ThenException()
    {
        var gameId = Guid.NewGuid();
        _gameRepositoryMock.Setup(m => m.GetGame(gameId)).ReturnsAsync(new Game(new List<string>{"Appel"}));
        var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _gameService.GuessWord(gameId, "Banaan"));
        Assert.That(ex.Message, Is.EqualTo("Guess is longer than 5 characters"));
    }
    
    [Test]
    public async Task GuessWord_IfGuessIsNotValid_ThenResponseIsNotValid()
    {
        var response = await _gameService.StartGame(2, 5);
        var gameId = response.GameId;
        _gameRepositoryMock.Setup(m => m.GetGame(gameId)).ReturnsAsync(new Game(new List<string>{"Appel"}));

        var result = await _gameService.GuessWord(gameId, "Totem");
        
        Assert.IsFalse(result.IsValid);
        Assert.IsEmpty(result.Matches);
    }
    
    [Test]
    public async Task GuessWord_IfGuessIsValid_ThenReturnGuessResult()
    {
        var response = await _gameService.StartGame(2, 5);
        var gameId = response.GameId;
        _gameRepositoryMock.Setup(m => m.GetGame(gameId)).ReturnsAsync(new Game(new List<string>{"Appel"}));

        var result = await _gameService.GuessWord(gameId, "Appel");
        
        Assert.IsTrue(result.IsValid);
        Assert.IsNotEmpty(result.Matches);
    }
}