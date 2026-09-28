using TwitcheryNet.Attributes;

namespace TwitcheryNet.Models.Helix.Analytics;

public class GetExtensionAnalyticsRequest : IQueryParameters, IWithPagination
{
    [QueryParameter("extension_id", false)]
    public string? ExtensionId { get; set; }

    [QueryParameter("type")]
    public string? Type { get; set; }

    [QueryParameter("started_at")]
    public DateTime? StartedAt { get; set; }

    [QueryParameter("ended_at")]
    public DateTime? EndedAt { get; set; }

    [QueryParameter("first")]
    public int? First { get; set; }

    [QueryParameter("after")]
    public string? After { get; set; }

    public GetExtensionAnalyticsRequest(string? extensionId = null, string? type = null, DateTime? startedAt = null, DateTime? endedAt = null, int? first = null, string? after = null)
    {
        ExtensionId = extensionId;
        Type = type;
        StartedAt = startedAt;
        EndedAt = endedAt;
        First = first;
        After = after;
    }
}