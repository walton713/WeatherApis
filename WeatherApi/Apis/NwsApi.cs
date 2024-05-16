using OneOf;
using WeatherApi.Models;
using WeatherApi.Models.Configuration;
using static WeatherApi.Constants;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherApi.Apis;

public class NwsApi(HttpClient client) : INwsApi
{
    public async Task<OneOf<NwsAlert, NwsError>> Alerts() =>
        await Get<NwsAlert>($"{NwsApiUrl}/alerts");

    public async Task<OneOf<NwsAlert, NwsError>> Alerts(NwsAlertConfiguration config) =>
        await Get<NwsAlert>($"{NwsApiUrl}/alerts{config.GetQueryString()}");

    private async Task<OneOf<T, NwsError>> Get<T>(string uriString)
    {
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriString)
        };
        request.Headers.Add("User-Agent", "Insomnia/8.6.1");

        var response = await client.SendAsync(request);
        return (await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync()))!;
    }
}
