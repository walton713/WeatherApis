using System.Text.Json.Serialization;

namespace WeatherApi.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NwsAlertSeverity
{
    Extreme,
    Severe,
    Moderate,
    Minor,
    Unknown
}