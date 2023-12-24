using EHA_AspNetCore.Models.Base;
using Newtonsoft.Json;
using NuGet.Packaging;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Payments;

[Table("PaymentConditions")]
public class PaymentCondition : Identification
{
    [Required]
    [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50 characters.")]
    [JsonProperty("Name")]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2")]
    [Range(0, 1000, ErrorMessage = "Fee percentage range is between 0 and 1000")]
    [DefaultValue(0)]
    [JsonProperty("Fee")]
    public decimal Fee { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2")]
    [Range(0, 100, ErrorMessage = "Discount percentage range is between 0 and 100")]
    [DefaultValue(0)]
    [JsonProperty("Discount")]
    public decimal Discount { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2")]
    [Range(0, 1000, ErrorMessage = "Fine percentage range is between 0 and 1000")]
    [DefaultValue(0)]
    [JsonProperty("Fine")]
    public decimal Fine { get; set; }

    [Required]
    [JsonProperty("InstalmentList")]
    public ICollection<Instalment> InstalmentList { get; set; } = new List<Instalment>();

    public PaymentCondition()
    {
        
    }

    public PaymentCondition(string name, decimal fee, decimal discount, decimal fine)
    {
        Name = name;
        Fee = fee;
        Discount = discount;
        Fine = fine;
    }

    public void ConfigureInstalmentList(List<Instalment> instalmentList)
    {
        InstalmentList.AddRange(instalmentList);
    }
}
