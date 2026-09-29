namespace TwitcheryNet.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class InjectRouteDataAttribute : Attribute
{
    public Type SourceType { get; }
    public string SourceMethodName { get; }

    public InjectRouteDataAttribute(Type sourceType, string sourceMethodName)
    {
        SourceType = sourceType;
        SourceMethodName = sourceMethodName;
    }
}