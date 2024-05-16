using System.Text.Json.Serialization;

namespace WeatherApi.Enums;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NwsAlertStatus
{
    Actual = 0,
    Exercise = 1,
    System = 2,
    Test = 4,
    Draft = 8
}
