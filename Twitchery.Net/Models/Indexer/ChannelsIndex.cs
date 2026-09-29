using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using TwitcheryNet.Attributes;
using TwitcheryNet.Models.Helix;
using TwitcheryNet.Models.Helix.Channels;
using TwitcheryNet.Models.Helix.Channels.Ads;
using TwitcheryNet.Models.Helix.Enumerations;
using TwitcheryNet.Models.Helix.Users;
using TwitcheryNet.Services.Interfaces;

namespace TwitcheryNet.Models.Indexer;

public class ChannelsIndex
{
    private ITwitchery Twitch { get; }

    [ActivatorUtilitiesConstructor]
    public ChannelsIndex(ITwitchery api)
    {
        Twitch = api;
    }

    public Channel? this[string broadcasterId] => GetChannelInformationAsync(broadcasterId).Result;

    [ApiRoute("GET", "channels")]
    [RequiresToken(TokenType.Both)]
    public async Task<GetChannelResponse?> GetChannelInformationAsync(GetChannelRequest request, CancellationToken cancellationToken = default)
    {
        return await Twitch.GetTwitchApiAsync<GetChannelRequest, GetChannelResponse>(request, typeof(ChannelsIndex), cancellationToken);
    }

    public async Task<Channel?> GetChannelInformationAsync(string broadcasterId, CancellationToken cancellationToken = default)
    {
        var channels = await GetChannelInformationAsync(new GetChannelRequest(broadcasterId), cancellationToken);
        var channel = channels?.ChannelInformations.FirstOrDefault();

        if (channel is not null)
        {
            await Twitch.InjectDataAsync(channel, cancellationToken);
        }

        return channel;
    }

    public async Task<Channel?> GetChannelInformationAsync(User user, CancellationToken cancellationToken = default)
    {
        var channels = await GetChannelInformationAsync(new GetChannelRequest(user.Id), cancellationToken);
        var channel = channels?.ChannelInformations.FirstOrDefault();

        if (channel is not null)
        {
            await Twitch.InjectDataAsync(channel, cancellationToken);
        }

        return channel;
    }

    [ApiRules(RouteRules.RequiresOwner | RouteRules.RequiresModerator)]
    [ApiRoute("GET", "channels/followers", "moderator:read:followers")]
    [RequiresToken(TokenType.UserAccess)]
    public async Task<GetChannelFollowersResponse?> GetChannelFollowersAsync(GetChannelFollowersRequest request, CancellationToken cancellationToken = default)
    {
        return await Twitch.GetTwitchApiAsync<GetChannelFollowersRequest, GetChannelFollowersResponse>(request, typeof(ChannelsIndex), cancellationToken);
    }

    [ApiRules(RouteRules.RequiresOwner | RouteRules.RequiresModerator)]
    [ApiRoute("GET", "channels/followers", "moderator:read:followers")]
    [RequiresToken(TokenType.UserAccess)]
    public async Task<GetAllChannelFollowersResponse?> GetAllChannelFollowersAsync(GetChannelFollowersRequest request, CancellationToken cancellationToken = default)
    {
        return await Twitch.GetTwitchApiAllAsync<GetChannelFollowersRequest, GetChannelFollowersResponse, GetAllChannelFollowersResponse>(request, typeof(ChannelsIndex), cancellationToken);
    }

    public async Task<List<Follower>> GetChannelFollowersAsync(string broadcasterId, CancellationToken cancellationToken = default)
    {
        var followers = await GetChannelFollowersAsync(new GetChannelFollowersRequest(broadcasterId), cancellationToken);
        return followers?.Followers ?? [];
    }

    public async IAsyncEnumerable<Follower> GetChannelFollowersAsync(Channel channel, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        string? cursor = null;
        do
        {
            var request = new GetChannelFollowersRequest(channel.BroadcasterId)
            {
                After = cursor
            };

            var followers = await GetChannelFollowersAsync(request, cancellationToken);

            if (followers is null)
            {
                yield break;
            }

            foreach (var follower in followers.Followers)
                yield return follower;

            cursor = followers.Pagination.Cursor;
        } while (!cancellationToken.IsCancellationRequested && !string.IsNullOrEmpty(cursor));
    }

    public async Task<List<Follower>> GetAllChannelFollowersAsync(string broadcasterId, CancellationToken cancellationToken = default)
    {
        var followers = await GetAllChannelFollowersAsync(new GetChannelFollowersRequest(broadcasterId), cancellationToken);
        return followers?.Followers ?? [];
    }

#warning Requires Testing
    /// <summary>
    /// Starts a commercial on the specified channel.<br/>
    /// <b>NOTE:</b> Only partners and affiliates may run commercials and they must be streaming live at the time.<br/>
    /// <b>NOTE:</b> Only the broadcaster may start a commercial; the broadcaster’s editors and moderators may not start commercials on behalf of the broadcaster.<br/>
    /// </summary>
    /// <param name="requestBody">The data related to start the commercial.</param>
    /// /// <param name="cancellationToken"></param>
    /// <returns>The data returned by the API, if any.</returns>
    [ApiRoute("POST", "channels/commercial", "channel:edit:commercial")]
    [RequiresToken(TokenType.Both)]
    [BroadcasterType(BroadcasterType.AffiliateOrPartner)]
    [ApiRules(RouteRules.RequiresOwner)]
    public async Task<StartCommercialResponse?> StartCommercialAsync(StartCommercialRequestBody requestBody, CancellationToken cancellationToken = default)
    {
        return await Twitch.PostTwitchApiAsync<StartCommercialRequestBody, StartCommercialResponse>(requestBody, typeof(ChannelsIndex), cancellationToken);
    }

    /// <summary>
    /// Starts a commercial on the specified channel.<br/>
    /// <b>NOTE:</b> Only partners and affiliates may run commercials and they must be streaming live at the time.<br/>
    /// <b>NOTE:</b> Only the broadcaster may start a commercial; the broadcaster’s editors and moderators may not start commercials on behalf of the broadcaster.<br/>
    /// </summary>
    /// <param name="broadcasterId">The ID of the partner or affiliate broadcaster that wants to run the commercial. This ID must match the user ID found in the OAuth token.</param>
    /// <param name="length">The length of the commercial to run, in seconds. Twitch tries to serve a commercial that’s the requested length, but it may be shorter or longer. The maximum length you should request is 180 seconds.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>The data returned by the API, if any.</returns>
    [BroadcasterType(BroadcasterType.AffiliateOrPartner)]
    public async Task<StartCommercialResponse?> StartCommercialAsync(string broadcasterId, int length, CancellationToken cancellationToken = default)
    {
        return await StartCommercialAsync(new StartCommercialRequestBody(broadcasterId, length), cancellationToken);
    }

    /// <summary>
    /// Starts a commercial on the specified channel.<br/>
    /// <b>NOTE:</b> Only partners and affiliates may run commercials and they must be streaming live at the time.<br/>
    /// <b>NOTE:</b> Only the broadcaster may start a commercial; the broadcaster’s editors and moderators may not start commercials on behalf of the broadcaster.<br/>
    /// </summary>
    /// <param name="broadcasterId">The ID of the partner or affiliate broadcaster that wants to run the commercial. This ID must match the user ID found in the OAuth token.</param>
    /// <param name="length">The length of the commercial to run, in seconds. Twitch tries to serve a commercial that’s the requested length, but it may be shorter or longer. The maximum length you should request is 180 seconds.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A boolean that indicates whether the commercial was successfully started or not.</returns>
    [BroadcasterType(BroadcasterType.AffiliateOrPartner)]
    public async Task<bool> TryStartCommercialAsync(string broadcasterId, int length, CancellationToken cancellationToken = default)
    {
        var result = await StartCommercialAsync(new StartCommercialRequestBody(broadcasterId, length), cancellationToken);

        return result != null;
    }

#warning Requires Testing
    /// <summary>
    /// This endpoint returns ad schedule related information, including snooze, when the last ad was run, when the next ad is scheduled, and if the channel is currently in pre-roll free time. Note that a new ad cannot be run until 8 minutes after running a previous ad.
    /// </summary>
    /// <param name="request">The data related to get the ad schedule.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [ApiRoute("GET", "channels/ads", "channel:read:ads")]
    [RequiresToken(TokenType.Both)]
    [BroadcasterType(BroadcasterType.AffiliateOrPartner)]
    public async Task<GetAdScheduleResponse?> GetAdScheduleAsync(GetAdScheduleRequest request, CancellationToken cancellationToken = default)
    {
        return await Twitch.GetTwitchApiAsync<GetAdScheduleRequest, GetAdScheduleResponse>(request, typeof(ChannelsIndex), cancellationToken);
    }

    /// <summary>
    /// This endpoint returns ad schedule related information, including snooze, when the last ad was run, when the next ad is scheduled, and if the channel is currently in pre-roll free time. Note that a new ad cannot be run until 8 minutes after running a previous ad.
    /// </summary>
    /// <param name="broadcasterId">Provided <c>broadcaster_id</c> must match the <c>user_id</c> in the auth token.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [BroadcasterType(BroadcasterType.AffiliateOrPartner)]
    public async Task<GetAdScheduleResponse?> GetAdScheduleAsync(string broadcasterId, CancellationToken cancellationToken = default)
    {
        return await GetAdScheduleAsync(new GetAdScheduleRequest(broadcasterId), cancellationToken);
    }

    /// <summary>
    /// This endpoint returns ad schedule related information, including snooze, when the last ad was run, when the next ad is scheduled, and if the channel is currently in pre-roll free time. Note that a new ad cannot be run until 8 minutes after running a previous ad.
    /// </summary>
    /// <param name="broadcasterId">Provided <c>broadcaster_id</c> must match the <c>user_id</c> in the auth token.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [BroadcasterType(BroadcasterType.AffiliateOrPartner)]
    public async Task<List<Schedule>> GetAdSchedulesAsync(string broadcasterId, CancellationToken cancellationToken = default)
    {
        var results = await GetAdScheduleAsync(new GetAdScheduleRequest(broadcasterId), cancellationToken);

        return results?.Schedules ?? [];
    }

#warning Requires Testing
    /// <summary>
    /// If available, pushes back the timestamp of the upcoming automatic mid-roll ad by 5 minutes. This endpoint duplicates the snooze functionality in the creator dashboard’s Ads Manager.
    /// </summary>
    /// <param name="requestBody"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [ApiRoute("POST", "channels/ads/schedule/snooze", "channel:manage:ads")]
    [RequiresToken(TokenType.Both)]
    [BroadcasterType(BroadcasterType.AffiliateOrPartner)]
    public async Task<SnoozeNextAdResponse?> SnoozeNextAdAsync(SnoozeNextAdRequestBody requestBody, CancellationToken cancellationToken = default)
    {
        return await Twitch.PostTwitchApiAsync<SnoozeNextAdRequestBody, SnoozeNextAdResponse>(requestBody, typeof(ChannelsIndex), cancellationToken);
    }

    /// <summary>
    /// If available, pushes back the timestamp of the upcoming automatic mid-roll ad by 5 minutes. This endpoint duplicates the snooze functionality in the creator dashboard’s Ads Manager.
    /// </summary>
    /// <param name="broadcasterId">Provided <c>broadcaster_id</c> must match the <c>user_id</c> in the auth token.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [BroadcasterType(BroadcasterType.AffiliateOrPartner)]
    public async Task<SnoozeNextAdResponse?> SnoozeNextAdAsync(string broadcasterId, CancellationToken cancellationToken = default)
    {
        return await SnoozeNextAdAsync(new SnoozeNextAdRequestBody(broadcasterId), cancellationToken);
    }

    /// <summary>
    /// If available, pushes back the timestamp of the upcoming automatic mid-roll ad by 5 minutes. This endpoint duplicates the snooze functionality in the creator dashboard’s Ads Manager.
    /// </summary>
    /// <param name="broadcasterId">Provided <c>broadcaster_id</c> must match the <c>user_id</c> in the auth token.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>A boolean that indicates whether the next ad was successfully snoozed or not.</returns>
    [BroadcasterType(BroadcasterType.AffiliateOrPartner)]
    public async Task<bool> TrySnoozeNextAdAsync(string broadcasterId, CancellationToken cancellationToken = default)
    {
        var result = await SnoozeNextAdAsync(new SnoozeNextAdRequestBody(broadcasterId), cancellationToken);

        return result != null;
    }

    public Task<bool> IsOwnerAsync(string broadcasterId, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Twitch.Me?.Channel?.BroadcasterId == broadcasterId);
    }

    public Task<bool> IsOwnerAsync(Channel channel, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(Twitch.Me?.Channel?.BroadcasterId == channel.BroadcasterId);
    }
}