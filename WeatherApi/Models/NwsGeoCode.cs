using System.Text.Json.Serialization;

namespace WeatherApi.Models;

public class NwsGeoCode
{
    [JsonPropertyName("UGC")]
    public IEnumerable<string> Ugc { get; set; }
    
    [JsonPropertyName("SAME")]
    public IEnumerable<string> Same { get; set; }
}