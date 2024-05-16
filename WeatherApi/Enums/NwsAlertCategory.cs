using System.Text.Json.Serialization;

namespace WeatherApi.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NwsAlertCategory
{
    Met,
    Geo,
    Safety,
    Security,
    Rescue,
    Fire,
    Health,
    Env,
    Transport,
    Infra,
    CBRNE,
    Other
}