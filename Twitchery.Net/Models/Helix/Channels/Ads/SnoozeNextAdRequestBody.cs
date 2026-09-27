using TwitcheryNet.Attributes;

namespace TwitcheryNet.Models.Helix.Channels.Ads;

public class SnoozeNextAdRequestBody : IQueryParameters
{
    [QueryParameter("broadcaster_id", true, true)]
    public string BroadcasterId { get; set; }

    public SnoozeNextAdRequestBody(string broadcasterId)
    {
        BroadcasterId = broadcasterId;
    }
}