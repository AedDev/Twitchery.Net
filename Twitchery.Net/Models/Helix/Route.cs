using System.Reflection;
using TwitcheryNet.Attributes;
using TwitcheryNet.Models.Helix.Enumerations;

namespace TwitcheryNet.Models.Helix;

public class Route
{
    public ApiRouteAttribute ApiRoute { get; }
    public ApiRulesAttribute? ApiRules { get; }
    public TokenType RequiredTokenType { get; }
    public MethodInfo CallerMethod { get; }
    public string Endpoint { get; }
    public string FullUrl => $"{Endpoint}{ApiRoute.Path}";
    public bool IsBetaRoute { get; }
    public BroadcasterType RequiredBroadcasterType { get; }
    public string? TargetBroadcasterId { get; }

    public Route(string endpoint, ApiRouteAttribute apiRoute, MethodInfo callerMethod, TokenType requiredTokenType, bool isBetaRoute, BroadcasterType requiredBroadcasterType, string? targetBroadcasterId = null, ApiRulesAttribute? apiRules = null)
    {
        Endpoint = endpoint;
        ApiRoute = apiRoute;
        ApiRules = apiRules;
        RequiredTokenType = requiredTokenType;
        CallerMethod = callerMethod;
        IsBetaRoute = isBetaRoute;
        RequiredBroadcasterType = requiredBroadcasterType;
    }
}