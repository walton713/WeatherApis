using System.Text.Json.Serialization;

namespace WeatherApi.Models;

public class NwsPaginationInfo
{
    [JsonPropertyName("next")]
    public string Next { get; set; }
}