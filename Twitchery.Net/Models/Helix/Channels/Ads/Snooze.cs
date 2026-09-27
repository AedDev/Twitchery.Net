using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Channels.Ads;

[JsonObject]
public class Snooze
{
    [JsonProperty("snooze_count")]
    public int SnoozeCount { get; set; }

    [JsonProperty("snooze_refresh_at")]
    public DateTime SnoozeRefreshAt { get; set; }

    [JsonProperty("next_ad_at")]
    public DateTime NextAdAt { get; set; }
}