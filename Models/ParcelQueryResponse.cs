using System.Text.Json.Serialization;

namespace DCADPropertyMap.Models;
public class ParcelQueryResponse
{
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

public class Feature
{
    [JsonPropertyName("attributes")]
    public ParcelDetails Attributes { get; set; }
}

public class ParcelDetails
{
    [JsonPropertyName("PARCELID")]
    public string ParcelID { get; set; }

    [JsonPropertyName("OWNERNME1")]
    public string OwnerName { get; set; }

    [JsonPropertyName("SITEADDRESS")]
    public string SiteAddress { get; set; }

    [JsonPropertyName("NGHBRHDCD")]
    public string Neighborhood { get; set; }

    [JsonPropertyName("MAPGRID")]
    public string MapGrid { get; set; }

    [JsonPropertyName("USEDSCRP")]
    public string AccountType { get; set; }

    [JsonPropertyName("CNVYNAME")]
    public string LegalDescription { get; set; }

    [JsonPropertyName("CNTASSDVAL")]
    public decimal? MarketValue { get; set; }

    [JsonPropertyName("IMPVALUE")]
    public decimal? ImprovementValue { get; set; }

    [JsonPropertyName("LNDVALUE")]
    public decimal? LandValue { get; set; }

    [JsonPropertyName("PSTLADDRESS")]
    public string OwnerAddress { get; set; }

    [JsonPropertyName("PSTLCITY")]
    public string OwnerCity { get; set; }

    [JsonPropertyName("PSTLSTATE")]
    public string OwnerState { get; set; }

    [JsonPropertyName("PSTLZIP5")]
    public string OwnerZip { get; set; }

    [JsonPropertyName("PSTLZIP4")]
    public string OwnerZip4 { get; set; }
}