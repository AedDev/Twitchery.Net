using TwitcheryNet.Attributes;

namespace TwitcheryNet.Models.Helix.Channels;

public class StartCommercialRequestBody
{
    [QueryParameter("broadcaster_id", true)]
    public string BroadcasterId { get; set; }

    [QueryParameter("length")]
    public int Length { get; set; }

    public StartCommercialRequestBody(string broadcasterId, int length)
    {
        Length = length;
        BroadcasterId = broadcasterId;
    }
}