using TwitcheryNet.Models.Helix;

namespace TwitcheryNet.Attributes;

public class BroadcasterTypeAttribute : Attribute
{
    public BroadcasterType BroadcasterType { get; }

    public BroadcasterTypeAttribute(BroadcasterType broadcasterType)
    {
        BroadcasterType = broadcasterType;
    }
}