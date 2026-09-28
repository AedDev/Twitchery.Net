using System.Collections;
using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Analytics;

[JsonObject]
public class GetAllExtensionAnalyticsResponse : IHasTotal, IFullResponse<GetExtensionAnalyticsResponse>, IEnumerable<ExtensionAnalytics>
{
    [JsonProperty("data")]
    public List<ExtensionAnalytics> ExtensionAnalytics { get; set; } = [];

    [JsonProperty("total")]
    public int Total { get; set; }

    public void Add(GetExtensionAnalyticsResponse item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));

        ExtensionAnalytics.AddRange(item.ExtensionAnalytics);
    }

    public IEnumerator<ExtensionAnalytics> GetEnumerator()
    {
        return ExtensionAnalytics.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}