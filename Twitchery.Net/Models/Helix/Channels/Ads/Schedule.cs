using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Channels.Ads;

[JsonObject]
public class Schedule
{
    /// <summary>
    /// The UTC timestamp of the broadcaster’s next scheduled ad. Empty if the channel has no ad scheduled or is not live.
    /// </summary>
    [JsonProperty("next_ad_at")]
    public DateTime NextAdAt { get; set; }

    /// <summary>
    /// The UTC timestamp of the broadcaster’s last ad-break. Empty if the channel has not run an ad or is not live.
    /// </summary>
    [JsonProperty("last_ad_at")]
    public DateTime LastAdAt { get; set; }

    /// <summary>
    /// The length in seconds of the scheduled upcoming ad break.
    /// </summary>
    [JsonProperty("duration")]
    public int Duration { get; set; }

    /// <summary>
    /// The amount of pre-roll free time remaining for the channel in seconds. Returns 0 if they are currently not pre-roll free.
    /// </summary>
    [JsonProperty("preroll_free_time")]
    public int PrerollFreeTime { get; set; }

    /// <summary>
    /// The number of snoozes available for the broadcaster.
    /// </summary>
    [JsonProperty("snooze_count")]
    public int SnoozeCount { get; set; }

    /// <summary>
    /// The UTC timestamp when the broadcaster will gain an additional snooze.
    /// </summary>
    [JsonProperty("snooze_refresh_at")]
    public DateTime SnoozeRefreshAt { get; set; }
}