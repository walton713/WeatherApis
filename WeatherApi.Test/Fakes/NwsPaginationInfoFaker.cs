using Bogus;
using WeatherApi.Models;

namespace WeatherApi.Test.Fakes;

public sealed class NwsPaginationInfoFaker : Faker<NwsPaginationInfo>
{
    public NwsPaginationInfoFaker()
    {
        RuleFor(p => p.Next, f => f.Internet.Url());
    }
}
