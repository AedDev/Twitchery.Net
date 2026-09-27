using Microsoft.Extensions.DependencyInjection;
using TwitcheryNet.Attributes;
using TwitcheryNet.Services.Implementations;
using TwitcheryNet.Models.Helix.Channels;
using TwitcheryNet.Models.Helix.Channels.Ads;

namespace TwitcheryNet.Models.Indexer;

public class AdsIndex
{
    private Twitchery Twitch { get; }

    [ActivatorUtilitiesConstructor]
    public AdsIndex(Twitchery api)
    {
        Twitch = api;
    }

#warning Requires Testing
    [ApiRoute("POST", "channels/commercial", "channel:edit:commercial")]
    [RequiresToken(TokenType.Both)]
    public async Task<StartCommercialResponse?> StartCommercialAsync(StartCommercialRequestBody requestBody, CancellationToken cancellationToken = default)
    {
        return await Twitch.PostTwitchApiAsync<StartCommercialRequestBody, StartCommercialResponse>(requestBody, typeof(AdsIndex), cancellationToken);
    }

#warning Requires Testing
    [ApiRoute("GET", "channels/ads", "channel:read:ads")]
    [RequiresToken(TokenType.Both)]
    public async Task<GetAdScheduleResponse?> GetAdScheduleAsync(GetAdScheduleRequest request, CancellationToken cancellationToken = default)
    {
        return await Twitch.GetTwitchApiAsync<GetAdScheduleRequest, GetAdScheduleResponse>(request, typeof(AdsIndex), cancellationToken);
    }

#warning Requires Testing
    [ApiRoute("POST", "channels/ads/schedule/snooze", "channel:manage:ads")]
    [RequiresToken(TokenType.Both)]
    public async Task<SnoozeNextAdResponse?> SnoozeNextAdAsync(SnoozeNextAdRequestBody requestBody, CancellationToken cancellationToken = default)
    {
        return await Twitch.PostTwitchApiAsync<SnoozeNextAdRequestBody, SnoozeNextAdResponse>(requestBody, typeof(AdsIndex), cancellationToken);
    }
}