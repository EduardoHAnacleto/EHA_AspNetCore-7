using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Models.People;
using EHA_AspNetCore.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Sales;

[Table("Sales")]
public class Sale : Identification
{
    [Display(Name = "Customer")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    [Required]
    [Display(Name = "Payment condition")]
    public int PaymentConditionId { get; set; }
    public PaymentCondition PaymentCondition { get; set; }

    [Display(Name = "Cancelled Date")]
    public DateTime? CancellationDate { get; set; }

    [Display(Name = "Motive of cancellation")]
    [MinLength(5, ErrorMessage = "Motive of cancellation must be at least 5 characters long.")]
    [MaxLength(100, ErrorMessage = "Motive of cancellation must have maximum of 100 characters.")]
    public string CancellationMotive { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2")]
    [Range(0, 20000)]
    public decimal Value { get; set; }

    [Required]
    public ICollection<ItemSale> SaleItemsList { get; set; } = new List<ItemSale>();

    public Sale()
    {
        
    }

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
