using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix;

[JsonObject]
public class Pagination
{
    [JsonProperty("cursor")]
    public string? Cursor { get; set; }
}