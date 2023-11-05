using EHA_AspNetCore_Angular.Models.Base;
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
    public string Name { get; private set; }

    [Required]
    [Column(TypeName = "decimal(5,2")]
    [Range(0, 1000, ErrorMessage = "Fee percentage range is between 0 and 1000")]
    [DefaultValue(0)]
    public decimal Fee { get; private set; }

    [Required]
    [Column(TypeName = "decimal(5,2")]
    [Range(0, 100, ErrorMessage = "Discount percentage range is between 0 and 100")]
    [DefaultValue(0)]
    public decimal Discount { get; private set; }

    [Required]
    [Column(TypeName = "decimal(5,2")]
    [Range(0, 1000, ErrorMessage = "Fine percentage range is between 0 and 1000")]
    [DefaultValue(0)]
    public decimal Fine { get; private set; }

    [Required]
    public ICollection<Instalment> InstalmentList { get; private set; } = new List<Instalment>();

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
