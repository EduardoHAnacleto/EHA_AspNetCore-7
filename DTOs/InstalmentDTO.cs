using EHA_AspNetCore.Models.Payments;
using Newtonsoft.Json;

namespace EHA_AspNetCore.DTOs;

public class InstalmentDTO
{
    [JsonProperty("Number")]
    public int Number { get; set; }

    [JsonProperty("Days")]
    public int Days { get; set; }

    [JsonProperty("Percentage")]
    public decimal Percentage { get; set; }

    [JsonProperty("PaymentMethodId")]
    public int PaymentMethodId { get; set; }

    [JsonProperty("PaymentMethod")]
    public string PaymentMethod { get; set; }
}
