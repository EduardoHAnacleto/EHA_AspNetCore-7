using EHA_AspNetCore.Models.Abstractions;
using EHA_AspNetCore.Models.Enums;
using EHA_AspNetCore.Models.Payments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EHA_AspNetCore.Models.People;

[Table("Customers")]
public class Customer : Person
{
    [Required]
    [Display(Name = "Customer type")]

    public CustomerTypeEnum CustomerType { get; set; }

    [Display(Name = "Preferred payment condition")]
    public int PaymentConditionId { get; set; }
    public PaymentCondition PaymentCondition { get; set; }

    public Customer()
    {

    }

    public Customer(string name, int gender, DateTime? dateOfBirth, string email, string street, string district,
    string buildingNumber, string addressAddition, string zipCode, string city, string country, string phoneNumber,
    CustomerTypeEnum customerType)
    : base(name, gender, (DateTime)dateOfBirth, email, street, district, buildingNumber, addressAddition, zipCode, city, country, phoneNumber)
    {
        CustomerType = customerType;
    }

    public void ConfigurePaymentCondition (PaymentCondition paymentCondition)
    {
        PaymentCondition = paymentCondition;
    }
}
