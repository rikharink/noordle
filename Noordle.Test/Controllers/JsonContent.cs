using System.Text;
using Newtonsoft.Json;

namespace Noordle.Test.Controllers;

public class JsonContent : StringContent
{
    private const string MediaType = "application/json";

    public JsonContent(object content) : base(JsonConvert.SerializeObject(content), Encoding.UTF8, MediaType) { }
}