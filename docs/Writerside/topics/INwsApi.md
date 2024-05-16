# INwsApi Interface

Reference

## Definition

Namespace: [WeatherApi.Apis](WeatherApi-Apis.md)<br />
Assembly: WeatherApi<br />
Source: [INwsApi.cs](https://github.com/walton713/WeatherApis/blob/master/WeatherApi/Apis/INwsApi.cs)

An abstraction for a component that can retrieve weather data from the National Weather Service (NWS) API.

```C#
public interface INwsApi
```

## Methods

<table>
<tr>
<td>Alerts()</td>
<td>Get the latest NWS alerts.</td>
</tr>
<tr>
<td>Alerts(NwsAlertConfiguration)</td>
<td>Get NWS alerts that match the parameters in the NwsAlertConfiguration.</td>
</tr>
</table>

<seealso>
<category ref="wrs">
<a href="WeatherApi-Apis.md">WeatherApi.Apis Namespace</a>
<a href="NwsApi.md">NwsApi Class</a>
</category>
<category ref="external">
<a href="https://www.weather.gov/documentation/services-web-api">NWS API Documentation</a>
</category>
</seealso>
