using System.Text.Json.Serialization;

namespace WeatherApi.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NwsAlertUrgency
{
    Immediate,
    Expected,
    Future,
    Past,
    Unknown
}