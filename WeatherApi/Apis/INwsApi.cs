using OneOf;
using WeatherApi.Models;
using WeatherApi.Models.Configuration;

namespace WeatherApi.Apis;

public interface INwsApi
{
    Task<OneOf<NwsAlert, NwsError>> Alerts();
    Task<OneOf<NwsAlert, NwsError>> Alerts(NwsAlertConfiguration config);
}
