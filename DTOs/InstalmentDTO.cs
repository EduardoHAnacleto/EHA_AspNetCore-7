using Newtonsoft.Json;

namespace EHA_AspNetCore.DTOs;

public class InstalmentDTO
{
    [JsonProperty("Number")]
    public int Number { get; set; }

    [JsonProperty("Days")]
    public int Days { get; set; }

    [JsonProperty("Percentage")]
    public string Percentage { get; set; }

    [JsonProperty("PaymentMethodId")]
    public string PaymentMethodId { get; set; }
}
