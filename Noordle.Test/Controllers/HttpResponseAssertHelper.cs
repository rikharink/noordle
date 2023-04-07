using System.Net;
using Newtonsoft.Json;

namespace Noordle.Test.Controllers;

public class HttpResponseAssertHelper
{
    public static async Task AssertOk(HttpResponseMessage response) => await AssertStatuscode(response, HttpStatusCode.OK);
    public static async Task<T> AssertOk<T>(HttpResponseMessage response) => await AssertStatuscode<T>(response, HttpStatusCode.OK);
    public static async Task<T> AssertBadRequest<T>(HttpResponseMessage response) => await AssertStatuscode<T>(response, HttpStatusCode.BadRequest);
    public static async Task Assert500(HttpResponseMessage response) => await AssertStatuscode(response, HttpStatusCode.InternalServerError);

    private static async Task<T> AssertStatuscode<T>(HttpResponseMessage response, HttpStatusCode statusCode)
    {
        await AssertStatuscode(response, statusCode);
        var message = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        return message;
    }

    public static async Task AssertStatuscode(HttpResponseMessage response, HttpStatusCode statusCode) => Assert.AreEqual(statusCode, response.StatusCode,
        $"Ontvangen statuscode: {response.StatusCode}. " +
        $"Ontvangen bericht: {await response.Content.ReadAsStringAsync()} " +
        $"Gebruikte uri: {response.RequestMessage.RequestUri}");
}