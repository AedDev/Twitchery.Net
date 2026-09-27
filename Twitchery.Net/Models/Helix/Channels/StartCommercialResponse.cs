using Newtonsoft.Json;
using TwitcheryNet.Attributes;

namespace TwitcheryNet.Models.Helix.Channels;

[JsonObject]
public class StartCommercialResponse
{
    [JsonProperty("data")]
    public List<Commercial> CommercialStartInfos { get; set; } = [];
}