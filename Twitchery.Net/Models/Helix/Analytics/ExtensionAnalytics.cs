using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Analytics;

[JsonObject]
public class DateRange
{
    [JsonProperty("started_at")]
    public DateTime? StartedAt { get; set; }

    [JsonProperty("ended_at")]
    public DateTime? EndedAt { get; set; }
}

[JsonObject]
public class ExtensionAnalytics
{
    [JsonProperty("extension_id")]
    public string? ExtensionId { get; set; }

    [JsonProperty("URL")]
    public string? Url { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; }

    [JsonProperty("date_range")]
    public DateRange? DateRange { get; set; }

    public ExtensionAnalytics(string? extensionId = null, string? url = null, string? type = null, DateRange? dateRange = null)
    {
        ExtensionId = extensionId;
        Url = url;
        Type = type;
        DateRange = dateRange;
    }
}