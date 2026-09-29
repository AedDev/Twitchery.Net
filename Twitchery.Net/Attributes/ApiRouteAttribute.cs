using System.Net;

namespace TwitcheryNet.Attributes;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class ApiRouteAttribute : Attribute
{
    public string HttpMethod { get; }
    public string Path { get; }
    public string[] RequiredScopes { get; }
    public HttpStatusCode RequiredStatusCode { get; set; } = HttpStatusCode.OK;

    public ApiRouteAttribute(string httpMethod, string path, params string[] requiredScopes)
    {
        HttpMethod = httpMethod;
        Path = path;
        RequiredScopes = requiredScopes;
    }
}