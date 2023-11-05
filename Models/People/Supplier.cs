using EHA_AspNetCore.Models.Abstractions;
using EHA_AspNetCore.Models.Payments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.People;

[Table("Suppliers")]
public class Supplier : Person
{
    [Display(Name = "State inscription")]
    public int StateInscription { get; private set; }

    [Display(Name = "Social reason")]
    [StringLength(50, MinimumLength = 10, ErrorMessage = "Social reason must be between 10 and 50 characters.")]
    public string SocialReason { get; private set; }

    [Display(Name = "Preferred payment condition")]
    public int PaymentConditionId { get; private set; }
    public PaymentCondition? PaymentCondition { get; private set; }

    public Supplier(string name, int gender, DateTime? dateOfBirth, string email, string street, string district, string buildingNumber,
        string addressAddition, string zipCode, string city, string country, string phoneNumber,
        int stateInscription, string socialReason)
        : base(name, gender, (DateTime) dateOfBirth, email, street, district, buildingNumber, addressAddition, zipCode, city, country, phoneNumber)
    {
        StateInscription = stateInscription;
        SocialReason = socialReason;
    }

    public void ConfigurePaymentCondition(PaymentCondition paymentCondition) 
    {
        PaymentCondition = paymentCondition;
    }
}
