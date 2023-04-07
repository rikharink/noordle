namespace Noordle.Test.Controllers;

public class WebServerTest
{
    private TestServer _testServer;
    protected HttpClient _client;

    [OneTimeSetUp]
    public void WebServerSetup()
    {
        _testServer = new TestServer();
        _client = _testServer.CreateClient();
    }

    [OneTimeTearDown]
    public void WebServerTearDown()
    {
        _testServer.Dispose();
    }
}