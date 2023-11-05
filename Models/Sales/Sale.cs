using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Models.People;
using EHA_AspNetCore_Angular.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Sales;

[Table("Sales")]
public class Sale : Identification
{
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; }

    [Required]
    [Display(Name = "Payment condition")]
    public int PaymentConditionId { get; set; }
    public PaymentCondition PaymentCondition { get; private set; }

    [Display(Name = "Cancelled Date")]
    public DateTime? CancellationDate { get; private set; }

    [Display(Name = "Motive of cancellation")]
    [MinLength(5, ErrorMessage = "Motive of cancellation must be at least 5 characters long.")]
    [MaxLength(100, ErrorMessage = "Motive of cancellation must have maximum of 100 characters.")]
    public string CancellationMotive { get; private set; }

    [Required]
    [Column(TypeName = "decimal(10,2")]
    public decimal Value { get; private set; }

    [Required]
    public ICollection<ItemSale> SaleItemsList { get; private set; } = new List<ItemSale>();

    public Sale(DateTime? cancellationDate, string cancellationMotive, decimal value)
    {
        CancellationDate = cancellationDate;
        Value = value;
        CancellationMotive = cancellationMotive;
    }

    public void ConfigureCustomer(Customer customer)
    {
        Customer = customer;
    }

    public void ConfigurePaymentCondition(PaymentCondition paymentCondition)
    {
        PaymentCondition = paymentCondition;
    }

    public void ConfigureSaleItemList(List<ItemSale> saleItemList)
    {
        SaleItemsList = saleItemList;
    }
}
