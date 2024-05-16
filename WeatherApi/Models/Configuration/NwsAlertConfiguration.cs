using WeatherApi.Enums;

namespace WeatherApi.Models.Configuration;

public class NwsAlertConfiguration
{
    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public NwsAlertStatus? Status { get; set; }

    public NwsAlertMessageType? MessageType { get; set; }

    public IEnumerable<string>? EventName { get; set; }

    public string GetQueryString()
    {
        var qParams = new List<string>();

        if (Start is not null) qParams.Add(Start.Value.ToQueryParam("start"));
        if (End is not null) qParams.Add(End.Value.ToQueryParam("end"));
        if (Status is not null) qParams.Add(Status!.Value.ToQueryParam("status"));
        if (MessageType is not null) qParams.Add(MessageType!.Value.ToQueryParam("message_type"));
        if (EventName is not null) qParams.Add(EventName.ToQueryParam("event"));

        return $"?{string.Join("&", qParams)}";
    }
}
