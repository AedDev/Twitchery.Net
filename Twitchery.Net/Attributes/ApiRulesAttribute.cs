using TwitcheryNet.Models.Helix;

namespace TwitcheryNet.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class ApiRulesAttribute : Attribute
{
    public RouteRules Rules { get; }

    public ApiRulesAttribute(RouteRules rules)
    {
        Rules = rules;
    }
}