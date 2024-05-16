using System.Text.Json.Serialization;

namespace WeatherApi.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NwsAlertCertainty
{
    Observed,
    Likely,
    Possible,
    Unlikely,
    Unknown
}