using EHA_AspNetCore.Models.Abstractions;
using EHA_AspNetCore.Models.Payments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.People;

[Table("Customers")]
public class Customer : Person
{
    [Required]
    [Range(0, 1)]
    [Display(Name = "Customer type")]
    public int CustomerType { get; private set; }

    [Display(Name = "Preferred payment condition")]
    public int PaymentConditionId { get; private set; }
    public PaymentCondition? PaymentCondition { get; private set; }

    public Customer(string name, int gender, DateTime? dateOfBirth, string email, string street, string district,
    string buildingNumber, string addressAddition, string zipCode, string city, string country, string phoneNumber,
    int customerType)
    : base(name, gender, (DateTime)dateOfBirth, email, street, district, buildingNumber, addressAddition, zipCode, city, country, phoneNumber)
    {
        CustomerType = customerType;
    }

    public void ConfigurePaymentCondition (PaymentCondition paymentCondition)
    {
        PaymentCondition = paymentCondition;
    }
}
