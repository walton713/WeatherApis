using System.Text.Json.Serialization;
using WeatherApi.Enums;

namespace WeatherApi.Models;

public class NwsAlert
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    [JsonPropertyName("features")]
    public IEnumerable<NwsAlertFeature> Features { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("updated")]
    public DateTime Updated { get; set; }
    
    [JsonPropertyName("pagination")]
    public NwsPaginationInfo Pagination { get; set; }
}

public class NwsAlertFeature
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    [JsonPropertyName("properties")]
    public NwsAlertProperties Properties { get; set; }
}

public class NwsAlertProperties
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("areaDesc")]
    public string AreaDescription { get; set; }
    
    [JsonPropertyName("geocode")]
    public NwsGeoCode GeoCode { get; set; }
    
    [JsonPropertyName("affectedZones")]
    public IEnumerable<string> AffectedZones { get; set; }
    
    [JsonPropertyName("references")]
    public IEnumerable<NwsAlertReference> References { get; set; }
    
    [JsonPropertyName("sent")]
    public DateTime Sent { get; set; }
    
    [JsonPropertyName("effective")]
    public DateTime Effective { get; set; }
    
    [JsonPropertyName("onset")]
    public DateTime? Onset { get; set; }
    
    [JsonPropertyName("expires")]
    public DateTime Expires { get; set; }
    
    [JsonPropertyName("ends")]
    public DateTime? Ends { get; set; }
    
    [JsonPropertyName("status")]
    public NwsAlertStatus Status { get; set; }
    
    [JsonPropertyName("messageType")]
    public NwsAlertMessageType MessageType { get; set; }
    
    [JsonPropertyName("category")]
    public NwsAlertCategory Category { get; set; }
    
    [JsonPropertyName("severity")]
    public NwsAlertSeverity Severity { get; set; }
    
    [JsonPropertyName("certainty")]
    public NwsAlertCertainty Certainty { get; set; }
    
    [JsonPropertyName("urgency")]
    public NwsAlertUrgency Urgency { get; set; }
    
    [JsonPropertyName("event")]
    public string Event { get; set; }
    
    [JsonPropertyName("sender")]
    public string Sender { get; set; }
    
    [JsonPropertyName("senderName")]
    public string SenderName { get; set; }
    
    [JsonPropertyName("headline")]
    public string? Headline { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("instruction")]
    public string? Instruction { get; set; }
    
    [JsonPropertyName("response")]
    public NwsAlertResponse Response { get; set; }
}

public class NwsAlertReference
{
    [JsonPropertyName("@id")]
    public string Id { get; set; }
    
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }
    
    [JsonPropertyName("sender")]
    public string Sender { get; set; }
    
    [JsonPropertyName("sent")]
    public DateTime Sent { get; set; }
}
