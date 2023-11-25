using Newtonsoft.Json;

namespace EHA_AspNetCore.DTOs;

public class PaymentConditionDTO
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Fee")]
    public string Fee { get; set; }

    [JsonProperty("Discount")]
    public string Discount { get; set; }

    [JsonProperty("Fine")]
    public string Fine { get; set; }

    [JsonProperty("InstalmentList")]
    public ICollection<InstalmentDTO> InstalmentList { get; set; } = new List<InstalmentDTO>();
}
