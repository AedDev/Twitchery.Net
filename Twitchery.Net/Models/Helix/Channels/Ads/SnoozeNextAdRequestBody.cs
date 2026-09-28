using Newtonsoft.Json;
using TwitcheryNet.Attributes;

namespace TwitcheryNet.Models.Helix.Channels.Ads;

[JsonObject]
public class SnoozeNextAdRequestBody : IQueryParameters
{
    [JsonProperty("broadcaster_id")]
    [QueryParameter("broadcaster_id", true)]
    public string BroadcasterId { get; set; }

    public SnoozeNextAdRequestBody(string broadcasterId)
    {
        BroadcasterId = broadcasterId;
    }
}