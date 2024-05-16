using System.Text.Json.Serialization;

namespace WeatherApi.Enums;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NwsAlertMessageType
{
    Alert = 0,
    Update = 1,
    Cancel = 2,
    Ack = 4,
    Error = 8
}
