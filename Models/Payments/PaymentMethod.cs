using EHA_AspNetCore_Angular.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Payments;

[Table("PaymentMethods")]
public class PaymentMethod : Identification
{
    [Required]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters.")]
    public string Name { get; private set; }

    public PaymentMethod(string name)
    {
        Name = name;
    }
}
