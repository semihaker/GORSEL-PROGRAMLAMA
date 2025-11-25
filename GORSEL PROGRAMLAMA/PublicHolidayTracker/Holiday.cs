using System.Text.Json.Serialization;

public class Holiday
{
    public string date { get; set; }
    public string localName { get; set; }
    public string name { get; set; }
    public string countryCode { get; set; }

    [JsonPropertyName("fixed")]
    public bool fixed_ { get; set; }

    [JsonPropertyName("global")]
    public bool global_ { get; set; }
}
