using Bogus;
using WeatherApi.Enums;
using WeatherApi.Models;

namespace WeatherApi.Test.Fakes;

public sealed class NwsAlertFaker : Faker<NwsAlert>
{
    public NwsAlertFaker()
    {
        Rules((f, alert) =>
        {
            alert.Type = "FeatureCollection";
            alert.Features = new NwsAlertFeatureFaker().GenerateBetween(1, 3);
            alert.Title = f.Lorem.Lines(1);
            alert.Updated = f.Date.Recent();
            alert.Pagination = new NwsPaginationInfoFaker().Generate();
        });
    }

    public static string ToJson(NwsAlert alert) =>
        $@"
{{
  ""@context"": [
    ""https://geojson.org/geojson-ld/geojson-context.jsonld"",
    {{
      ""@version"": ""1.1"",
      ""wx"": ""https://api.weather.gov/ontology#"",
      ""@vocab"": ""https://api.weather.gov/ontology#""
    }}
  ],
  ""type"": ""{alert.Type}"",
  ""features"": [{string.Join(',', alert.Features.Select(feature => $@"{{
      ""id"": ""{feature.Id}"",
      ""type"": ""{feature.Type}"",
      ""geometry"": null,
      ""properties"": {{
        ""@id"": ""https://api.weather.gov/alerts/urn:oid:2.49.0.1.840.0-KEEPALIVE-9067"",
        ""@type"": ""wx:Alert"",
        ""id"": ""{feature.Properties.Id}"",
        ""areaDesc"": ""{feature.Properties.AreaDescription}"",
        ""geocode"": {{
          ""SAME"": [{string.Join(",", feature.Properties.GeoCode.Same.Select(s => $@"""{s}"""))}],
          ""UGC"": [{string.Join(",", feature.Properties.GeoCode.Ugc.Select(s => $@"""{s}"""))}]
        }},
        ""affectedZones"": [{string.Join(",", feature.Properties.AffectedZones.Select(s => $@"""{s}"""))}],
        ""references"": [{string.Join(",", feature.Properties.References.Select(reference => $@"{{
            ""@id"": ""{reference.Id}"",
            ""identifier"": ""{reference.Identifier}"",
            ""sender"": ""{reference.Sender}"",
            ""sent"": ""{reference.Sent:O}""
          }}"))}],
        ""sent"": ""{feature.Properties.Sent:O}"",
        ""effective"": ""{feature.Properties.Effective:O}"",
        ""onset"": {(feature.Properties.Onset is null ? "null" : $@"""{feature.Properties.Onset:O}""")},
        ""expires"": ""{feature.Properties.Expires:O}"",
        ""ends"": {(feature.Properties.Ends is null ? "null" : $@"""{feature.Properties.Ends:O}""")},
        ""status"": ""{feature.Properties.Status.ToString()}"",
        ""messageType"": ""{feature.Properties.MessageType.ToString()}"",
        ""category"": ""{feature.Properties.Category.ToString()}"",
        ""severity"": ""{feature.Properties.Severity.ToString()}"",
        ""certainty"": ""{feature.Properties.Certainty.ToString()}"",
        ""urgency"": ""{feature.Properties.Urgency.ToString()}"",
        ""event"": ""{feature.Properties.Event}"",
        ""sender"": ""{feature.Properties.Sender}"",
        ""senderName"": ""{feature.Properties.SenderName}"",
        ""headline"": {(feature.Properties.Headline is null ? "null" : $@"""{feature.Properties.Headline}""")},
        ""description"": ""{feature.Properties.Description}"",
        ""instruction"": {(feature.Properties.Instruction is null ? "null" : $@"""{feature.Properties.Instruction}""")},
        ""response"": ""{feature.Properties.Response.ToString()}""
        }}
    }}"))}],
  ""title"": ""{alert.Title}"",
  ""updated"": ""{alert.Updated:O}"",
  ""pagination"": {{
    ""next"": ""{alert.Pagination.Next}""
  }}
}}
";
}

public sealed class NwsAlertFeatureFaker : Faker<NwsAlertFeature>
{
    public NwsAlertFeatureFaker()
    {
        Rules((f, feature) =>
        {
            feature.Id = f.Lorem.Word();
            feature.Type = "Feature";
            feature.Properties = new NwsAlertPropertiesFaker().Generate();
        });
    }
}

public sealed class NwsAlertPropertiesFaker : Faker<NwsAlertProperties>
{
    public NwsAlertPropertiesFaker()
    {
        Rules((f, prop) =>
        {
            prop.Id = f.Lorem.Word();
            prop.AreaDescription = f.Address.FullAddress();
            prop.GeoCode = new NwsGeoCodeFaker().Generate();
            prop.AffectedZones = f.Lorem.Words();
            prop.References = new NwsAlertReferenceFaker().GenerateBetween(1, 3);
            prop.Sent = f.Date.Recent();
            prop.Effective = f.Date.Recent();
            prop.Onset = f.Date.Recent().OrNull(f, 0.1f);
            prop.Expires = f.Date.Soon();
            prop.Ends = f.Date.Soon().OrNull(f, 0.1f);
            prop.Status = f.PickRandom<NwsAlertStatus>();
            prop.MessageType = f.PickRandom<NwsAlertMessageType>();
            prop.Category = f.PickRandom<NwsAlertCategory>();
            prop.Severity = f.PickRandom<NwsAlertSeverity>();
            prop.Certainty = f.PickRandom<NwsAlertCertainty>();
            prop.Urgency = f.PickRandom<NwsAlertUrgency>();
            prop.Event = f.Lorem.Lines(1);
            prop.Sender = f.Internet.Email();
            prop.SenderName = f.Person.FullName;
            prop.Headline = f.Lorem.Lines(1).OrNull(f, 0.1f);
            prop.Description = f.Lorem.Lines(1);
            prop.Instruction = f.Lorem.Lines(1).OrNull(f, 0.1f);
            prop.Response = f.PickRandom<NwsAlertResponse>();
        });
    }
}

public sealed class NwsAlertReferenceFaker : Faker<NwsAlertReference>
{
    public NwsAlertReferenceFaker()
    {
        Rules((f, reference) =>
        {
            reference.Id = f.Lorem.Word();
            reference.Identifier = f.Lorem.Word();
            reference.Sender = f.Internet.Email();
            reference.Sent = f.Date.Recent();
        });
    }
}
