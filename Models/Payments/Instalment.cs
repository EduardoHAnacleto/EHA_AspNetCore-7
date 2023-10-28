using EHA_AspNetCore_Angular.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Payments;

[Table("Instalments")]
public class Instalment : Identification
{
    [Required]
    [Range(1, 150, ErrorMessage = "Instalment quantity must be between 1 and 150.")]
    public int Number { get; private set; }

    [Required]
    [MinLength(0, ErrorMessage = "Day must be 0 or higher.")]
    [MaxLength(365, ErrorMessage = "Day must not be higher than 365.")]
    public int Days { get; private set; }

    [Required]
    [MinLength(1, ErrorMessage = "Percentage must be higher than 0.")]
    [MaxLength(100, ErrorMessage = "Percentage must be maximum of 100.")]
    public decimal Percentage { get; private set; }

    [Required]
    public int PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; private set; }

    public Instalment(int number, int days, decimal percentage, PaymentMethod paymentMethod)
    {
        Number = number;
        Days = days;
        Percentage = percentage;
        PaymentMethod = paymentMethod;
    }
}
