using System.Net;
using FluentAssertions;
using WeatherApi.Apis;
using WeatherApi.Enums;
using WeatherApi.Models.Configuration;
using WeatherApi.Test.Fakes;
using static WeatherApi.Test.MockMessageHandler;

namespace WeatherApi.Test.Apis;

public class NwsApiTests
{
    [Fact]
    public async Task GivenNoRouteParams_ReturnsAlertObject()
    {
        var alert = new NwsAlertFaker().Generate();
        var sut = new NwsApi(new HttpClient(ConfigureMockHttpMessageHandler(
            request => request.RequestUri == new Uri($"{Constants.NwsApiUrl}/alerts"),
            NwsAlertFaker.ToJson(alert),
            HttpStatusCode.OK)));
        var actual = await sut.Alerts();
        actual.Value.Should().BeEquivalentTo(alert);
    }

    [Fact]
    public async Task GivenStartRouteParam_ReturnsAlertObject()
    {
        var alert = new NwsAlertFaker().Generate();
        var config = new NwsAlertConfiguration
        {
            Start = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc)
        };
        var sut = new NwsApi(new HttpClient(ConfigureMockHttpMessageHandler(
            request => request.RequestUri == new Uri($"{Constants.NwsApiUrl}/alerts?start=2024-01-01T12:00:00Z"),
            NwsAlertFaker.ToJson(alert),
            HttpStatusCode.OK)));
        var actual = await sut.Alerts(config);
        actual.AsT0.Should().BeEquivalentTo(alert);
    }

    [Fact]
    public async Task GivenEndRouteParam_ReturnsAlertObject()
    {
        var alert = new NwsAlertFaker().Generate();
        var config = new NwsAlertConfiguration
        {
            End = new DateTime(2024, 1, 1, 12, 0, 0, DateTimeKind.Utc)
        };
        var sut = new NwsApi(new HttpClient(ConfigureMockHttpMessageHandler(
            request => request.RequestUri == new Uri($"{Constants.NwsApiUrl}/alerts?end=2024-01-01T12:00:00Z"),
            NwsAlertFaker.ToJson(alert),
            HttpStatusCode.OK)));
        var actual = await sut.Alerts(config);
        actual.AsT0.Should().BeEquivalentTo(alert);
    }

    [Fact]
    public async Task GivenSingleStatusRouteParam_ReturnsAlertObject()
    {
        var alert = new NwsAlertFaker().Generate();
        var config = new NwsAlertConfiguration
        {
            Status = NwsAlertStatus.Actual
        };
        var sut = new NwsApi(new HttpClient(ConfigureMockHttpMessageHandler(
            request => request.RequestUri == new Uri($"{Constants.NwsApiUrl}/alerts?status=actual"),
            NwsAlertFaker.ToJson(alert),
            HttpStatusCode.OK)));
        var actual = await sut.Alerts(config);
        actual.AsT0.Should().BeEquivalentTo(alert);
    }

    [Fact]
    public async Task GivenMultipleStatusRouteParam_ReturnsAlertObject()
    {
        var alert = new NwsAlertFaker().Generate();
        var config = new NwsAlertConfiguration
        {
            Status = NwsAlertStatus.Exercise | NwsAlertStatus.Draft
        };
        var sut = new NwsApi(new HttpClient(ConfigureMockHttpMessageHandler(
            request => request.RequestUri == new Uri($"{Constants.NwsApiUrl}/alerts?status=exercise,draft"),
            NwsAlertFaker.ToJson(alert),
            HttpStatusCode.OK)));
        var actual = await sut.Alerts(config);
        actual.AsT0.Should().BeEquivalentTo(alert);
    }

    [Fact]
    public async Task GivenSingleMessageTypeRouteParam_ReturnsAlertObject()
    {
        var alert = new NwsAlertFaker().Generate();
        var config = new NwsAlertConfiguration
        {
            MessageType = NwsAlertMessageType.Alert
        };
        var sut = new NwsApi(new HttpClient(ConfigureMockHttpMessageHandler(
            request => request.RequestUri == new Uri($"{Constants.NwsApiUrl}/alerts?message_type=alert"),
            NwsAlertFaker.ToJson(alert),
            HttpStatusCode.OK)));
        var actual = await sut.Alerts(config);
        actual.AsT0.Should().BeEquivalentTo(alert);
    }

    [Fact]
    public async Task GivenMultipleMessageTypeRouteParam_ReturnsAlertObject()
    {
        var alert = new NwsAlertFaker().Generate();
        var config = new NwsAlertConfiguration
        {
            MessageType = NwsAlertMessageType.Update | NwsAlertMessageType.Cancel
        };
        var sut = new NwsApi(new HttpClient(ConfigureMockHttpMessageHandler(
            request => request.RequestUri == new Uri($"{Constants.NwsApiUrl}/alerts?message_type=update,cancel"),
            NwsAlertFaker.ToJson(alert),
            HttpStatusCode.OK)));
        var actual = await sut.Alerts(config);
        actual.AsT0.Should().BeEquivalentTo(alert);
    }

    [Fact]
    public async Task GivenSingleEventNameRouteParam_ReturnsAlertObject()
    {
        var alert = new NwsAlertFaker().Generate();
        var config = new NwsAlertConfiguration
        {
            EventName = ["Tornado Watch"]
        };
        var sut = new NwsApi(new HttpClient(ConfigureMockHttpMessageHandler(
            request => request.RequestUri == new Uri($"{Constants.NwsApiUrl}/alerts?event=Tornado%20Watch"),
            NwsAlertFaker.ToJson(alert),
            HttpStatusCode.OK)));
        var actual = await sut.Alerts(config);
        actual.AsT0.Should().BeEquivalentTo(alert);
    }

    [Fact]
    public async Task GivenMultipleEventNameRouteParam_ReturnsAlertObject()
    {
        var alert = new NwsAlertFaker().Generate();
        var config = new NwsAlertConfiguration
        {
            EventName = ["Tornado Warning", "Flash Flood Watch"]
        };
        var sut = new NwsApi(new HttpClient(ConfigureMockHttpMessageHandler(
            request => request.RequestUri == new Uri($"{Constants.NwsApiUrl}/alerts?event=Tornado%20Warning,Flash%20Flood%20Watch"),
            NwsAlertFaker.ToJson(alert),
            HttpStatusCode.OK)));
        var actual = await sut.Alerts(config);
        actual.AsT0.Should().BeEquivalentTo(alert);
    }
}
