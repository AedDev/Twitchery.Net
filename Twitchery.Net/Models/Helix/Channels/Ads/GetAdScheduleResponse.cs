using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Channels.Ads;

[JsonObject]
public class GetAdScheduleResponse
{
    [JsonProperty("data")]
    public List<Schedule> AdSchedules { get; set; } = [];
}