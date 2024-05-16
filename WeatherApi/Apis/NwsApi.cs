using OneOf;
using WeatherApi.Models;
using WeatherApi.Models.Configuration;
using static WeatherApi.Constants;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherApi.Apis;

public interface INwsApi
{
    Task<OneOf<NwsAlert, NwsError>> Alerts(NwsAlertConfiguration? config = null);
}

public class NwsApi(HttpClient client) : INwsApi
{
    public async Task<OneOf<NwsAlert, NwsError>> Alerts(NwsAlertConfiguration? config = null)
    {
        var uriString = $"{NwsApiUrl}/alerts";

        if (config is not null) uriString += config.GetQueryString();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriString)
        };
        request.Headers.Add("User-Agent", "Insomnia/8.6.1");

        var response = await client.SendAsync(request);
        return (await JsonSerializer.DeserializeAsync<NwsAlert>(await response.Content.ReadAsStreamAsync()))!;
    }
}
