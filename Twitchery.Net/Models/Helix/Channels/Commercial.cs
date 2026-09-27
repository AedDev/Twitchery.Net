using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Channels;

[JsonObject]
public class Commercial
{
    [JsonProperty("length")]
    public int Length { get; set; }

    [JsonProperty("message")]
    public string? Message { get; set; }

    [JsonProperty("retry_after")]
    public int RetryAfter { get; set; }
}