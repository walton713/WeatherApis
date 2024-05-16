using System.Text.Json.Serialization;

namespace WeatherApi.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum NwsAlertResponse
{
    Shelter,
    Evacuate,
    Prepare,
    Execute,
    Avoid,
    Monitor,
    Assess,
    AllClear,
    None
}