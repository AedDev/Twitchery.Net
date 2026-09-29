using Newtonsoft.Json;
using TwitcheryNet.Attributes;

namespace TwitcheryNet.Models.Helix.Channels.Ads;

[JsonObject]
public class SnoozeNextAdRequestBody : IQueryParameters
{
    /// <summary>
    /// Provided <c>broadcaster_id</c> must match the <c>user_id</c> in the auth token.
    /// </summary>
    [JsonProperty("broadcaster_id")]
    [QueryParameter("broadcaster_id", true)]
    [TargetBroadcaster]
    public string BroadcasterId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="broadcasterId">Provided <c>broadcaster_id</c> must match the <c>user_id</c> in the auth token.</param>
    public SnoozeNextAdRequestBody(string broadcasterId)
    {
        BroadcasterId = broadcasterId;
    }
}