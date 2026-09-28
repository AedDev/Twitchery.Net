using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Analytics;

[JsonObject]
public class GetExtensionAnalyticsResponse : IHasPagination
{
    [JsonProperty("data")]
    public List<ExtensionAnalytics> ExtensionAnalytics { get; set; } = [];

    [JsonProperty("pagination")]
    public Pagination? Pagination { get; set; }
}