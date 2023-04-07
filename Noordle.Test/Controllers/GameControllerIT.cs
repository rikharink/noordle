using Microsoft.AspNetCore.Mvc;
using Noordle.Models;

namespace Noordle.Test.Controllers;

public class GameControllerIT : WebServerTest
{
    private static string Route = "api/app/game";

    [Test]
    public async Task StartNewGame()
    {
        var response =
            await _client.PostAsync(Route, new JsonContent(new StartGameDto { BoardCount = 4, WordLength = 5 }));


        var result = await HttpResponseAssertHelper.AssertOk<ResponseDto>(response);

        Assert.IsNotNull(result);
    }
    
    [Test]
    public async Task StartNewGame_IfRequestNotValid_ThenReturnBadRequest()
    {
        var response =
            await _client.PostAsync(Route, new JsonContent(new StartGameDto()));

        var result = await HttpResponseAssertHelper.AssertBadRequest<ValidationProblemDetails>(response);

        Assert.That(result.Errors, Has.Count.EqualTo(2));
        Assert.Multiple(() =>
        {
            Assert.That(result.Errors[nameof(StartGameDto.BoardCount)][0], Is.EqualTo("A minimum of 1 board is required to play a game"));
            Assert.That(result.Errors[nameof(StartGameDto.WordLength)][0], Is.EqualTo("A minimum of 3 letters is required to play a game"));
        });
    }

    [Test]
    public async Task PlayGame()
    {
        // Start game
        var response = await _client.PostAsync(Route, new JsonContent(new StartGameDto { BoardCount = 4, WordLength = 5 }));
        var resultStart = await HttpResponseAssertHelper.AssertOk<ResponseDto>(response);
        var gameId = resultStart.GameId;
        
        // First guess
        response = await _client.PutAsync($"{Route}/{gameId}/Appel", null);
        var resultGuess = await HttpResponseAssertHelper.AssertOk<GuessResponse>(response);
        Assert.That(resultGuess, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(resultGuess.IsValid, Is.True);
            Assert.That(resultGuess.Matches, Has.Length.EqualTo(4));
            foreach (var wordMatch in resultGuess.Matches)
            {
                Assert.That(wordMatch.Letters, Has.Length.EqualTo(5));
            }
        });
    }
    
    [Test]
    public async Task PlayGameAndGiveUp()
    {
        // Start game
        var response = await _client.PostAsync(Route, new JsonContent(new StartGameDto { BoardCount = 4, WordLength = 5 }));
        var resultStart = await HttpResponseAssertHelper.AssertOk<ResponseDto>(response);
        var gameId = resultStart.GameId;
        
        // First guess
        await _client.PutAsync($"{Route}/{gameId}/Appel", null);

        // Give up
        response = await _client.DeleteAsync($"{Route}/{gameId}");
        await HttpResponseAssertHelper.AssertOk(response);
        
        // Guessing is no longer possible
        response = await _client.PutAsync($"{Route}/{gameId}/Aapje", null);
        await HttpResponseAssertHelper.Assert500(response);
    }
}

public class ResponseDto
{
    public Guid GameId { get; set; }
}