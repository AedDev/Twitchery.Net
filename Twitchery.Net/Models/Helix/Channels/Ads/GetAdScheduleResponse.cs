using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Channels.Ads;

[JsonObject]
public class GetAdScheduleResponse
{
    /// <summary>
    /// A list that contains information related to the channel’s ad schedule.
    /// </summary>
    [JsonProperty("data")]
    public List<Schedule> Schedules { get; set; } = [];
}