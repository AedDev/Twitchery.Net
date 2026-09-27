using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Channels.Ads;

[JsonObject]
public class SnoozeNextAdResponse
{
    [JsonProperty("data")]
    public List<Snooze> AdSnoozes { get; set; } = [];
}