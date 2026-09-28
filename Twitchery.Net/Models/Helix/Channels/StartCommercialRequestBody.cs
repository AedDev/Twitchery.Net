using Newtonsoft.Json;
using TwitcheryNet.Attributes;

namespace TwitcheryNet.Models.Helix.Channels;

[JsonObject]
public class StartCommercialRequestBody
{
    [JsonProperty("broadcaster_id")]
    public string BroadcasterId { get; set; }

    [JsonProperty("length")]
    public int Length { get; set; }

    public StartCommercialRequestBody(string broadcasterId, int length)
    {
        Length = length;
        BroadcasterId = broadcasterId;
    }
}