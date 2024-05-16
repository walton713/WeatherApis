using System.Linq.Expressions;
using System.Net;
using NSubstitute;
using NSubstitute.Extensions;

namespace WeatherApi.Test;

public class MockHttpMessageHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return MockSend(request, cancellationToken);
    }

    public virtual Task<HttpResponseMessage> MockSend(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public static class MockMessageHandler
{
    public static MockHttpMessageHandler ConfigureMockHttpMessageHandler(IEnumerable<(Expression<Predicate<HttpRequestMessage>> predicate, string response, HttpStatusCode statusCode)> calls)
    {
        var mockHandler = Substitute.ForPartsOf<MockHttpMessageHandler>();
        foreach (var call in calls)
        {
            mockHandler.Configure()
                .MockSend(Arg.Is(call.predicate), Arg.Any<CancellationToken>())
                .Returns(new HttpResponseMessage
                {
                    Content = new StringContent(call.response),
                    StatusCode = call.statusCode
                });
        }

        return mockHandler;
    }

    public static MockHttpMessageHandler ConfigureMockHttpMessageHandler(Expression<Predicate<HttpRequestMessage>> predicate,
        string response, HttpStatusCode statusCode)
    {
        var mockHandler = Substitute.ForPartsOf<MockHttpMessageHandler>();
        mockHandler.Configure()
            .MockSend(Arg.Is(predicate), Arg.Any<CancellationToken>())
            .Returns(new HttpResponseMessage
            {
                Content = new StringContent(response),
                StatusCode = statusCode
            });
        return mockHandler;
    }
}
