using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Channels.Ads;

[JsonObject]
public class Schedule
{
    [JsonProperty("next_ad_at")]
    public DateTime NextAdAt { get; set; }

    [JsonProperty("last_ad_at")]
    public DateTime LastAdAt { get; set; }

    [JsonProperty("duration")]
    public int Duration { get; set; }

    [JsonProperty("preroll_free_time")]
    public int PrerollFreeTime { get; set; }

    [JsonProperty("snooze_count")]
    public int SnoozeCount { get; set; }

    [JsonProperty("snooze_refresh_at")]
    public DateTime SnoozeRefreshAt { get; set; }
}