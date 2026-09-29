using Newtonsoft.Json;

namespace TwitcheryNet.Models.Helix.Channels;

[JsonObject]
public class StartCommercialRequestBody
{
    /// <summary>
    /// The ID of the partner or affiliate broadcaster that wants to run the commercial. This ID must match the user ID found in the OAuth token.
    /// </summary>
    [JsonProperty("broadcaster_id")]
    public string BroadcasterId { get; set; }

    /// <summary>
    /// The length of the commercial to run, in seconds. Twitch tries to serve a commercial that’s the requested length, but it may be shorter or longer. The maximum length you should request is 180 seconds.
    /// </summary>
    [JsonProperty("length")]
    public int Length { get; set; }

    /// <summary>
    /// The request body to be sent to the Twitch API to start a commercial on the specified channel.
    /// </summary>
    /// <param name="broadcasterId">The ID of the partner or affiliate broadcaster that wants to run the commercial. This ID must match the user ID found in the OAuth token.</param>
    /// <param name="length">The length of the commercial to run, in seconds. Twitch tries to serve a commercial that’s the requested length, but it may be shorter or longer. The maximum length you should request is 180 seconds.</param>
    public StartCommercialRequestBody(string broadcasterId, int length)
    {
        Length = length;
        BroadcasterId = broadcasterId;
    }
}