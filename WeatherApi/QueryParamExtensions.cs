using System.Text.Json;
using System.Web;

namespace WeatherApi;

public static class QueryParamExtensions
{
    public static string ToQueryParam(this DateTime value, string name) =>
        $"{name}={value.ToUniversalTime().ToString("u").Replace(" ", "T")}";

    public static string ToQueryParam<T>(this T value, string name) where T : struct, IConvertible =>
        $"{name}={JsonSerializer.Serialize(value).ToLower().Replace("\"", "").Replace(" ", "")}";

    public static string ToQueryParam(this IEnumerable<string> value, string name) =>
        $"{name}={HttpUtility.UrlPathEncode(string.Join(",", value))}";
}
