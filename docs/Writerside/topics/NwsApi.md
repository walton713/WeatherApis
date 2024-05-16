# NwsApi Class

Reference

## Definition

Namespace: [WeatherApi.Apis](WeatherApi-Apis.md)<br />
Assembly: WeatherApi<br />
Source: [NwsApi.cs](https://github.com/walton713/WeatherApis/blob/master/WeatherApi/Apis/NwsApi.cs)

Provides a class for retrieving weather data from the National Weather Service (NWS) API.

```C#
public class NwsApi(HttpClient client) : INwsApi
```

Inheritance &nbsp;
[Object](https://learn.microsoft.com/en-us/dotnet/api/system.object?view=net-8.0) &rarr; NwsApi

## Examples

```c#
static readonly HttpClient client = new HttpClient();

var api = new NwsApi(client);
var alerts = api.Alerts();
```

## Remarks

For more information on the NWS API visit [their documentation](https://www.weather.gov/documentation/services-web-api)

## Constructors

<table>
<tr>
<td>NwsApi(HttpClient)</td>
<td>Initializes a new instance of the NwsApi class using an instance of HttpClient.</td>
</tr>
</table>

## Methods

<table>
<tr>
<td>Alerts()</td>
<td>Get The latest NWS alerts.</td>
</tr>
<tr>
<td>Alerts(NwsAlertConfiguration)</td>
<td>Get NWS alerts that match the parameters in the NwsAlertConfiguration.</td>
</tr>
</table>

<seealso>
<category ref="wrs">
<a href="WeatherApi-Apis.md">WeatherApi.Apis Namespace</a>
<a href="INwsApi.md">INwsApi Interface</a>
</category>
<category ref="external">
<a href="https://www.weather.gov/documentation/services-web-api">NWS API Documentation</a>
</category>
</seealso>