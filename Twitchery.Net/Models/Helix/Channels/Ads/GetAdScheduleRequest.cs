using TwitcheryNet.Attributes;

namespace TwitcheryNet.Models.Helix.Channels.Ads;

public class GetAdScheduleRequest : IQueryParameters
{
    [QueryParameter("broadcaster_id", true, true)]
    public string BroadcasterId { get; set; }

    public GetAdScheduleRequest(string broadcasterId)
    {
        BroadcasterId = broadcasterId;
    }
}