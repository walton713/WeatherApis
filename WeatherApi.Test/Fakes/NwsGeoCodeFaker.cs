using Bogus;
using WeatherApi.Models;

namespace WeatherApi.Test.Fakes;

public sealed class NwsGeoCodeFaker : Faker<NwsGeoCode>
{
    public NwsGeoCodeFaker()
    {
        Rules((f, geoCode) =>
        {
            geoCode.Ugc = f.Lorem.Words();
            geoCode.Same = f.Lorem.Words();
        });
    }
}
