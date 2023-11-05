using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Models.People;
using EHA_AspNetCore.Models.Sales;
using EHA_AspNetCore_Angular.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Bills;

[Table("BillsToReceive")]
public class BillToReceive
{
    [Key]
    public int Id { get; }

    [Required]
    [Display(Name = "Customer")]
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; }

    [Display(Name = "Sale")]
    public int SaleId { get; private set; }
    public Sale? Sale { get; private set; }

    [Required]
    [Display(Name = "Payment method")]
    public int PaymentMethodId { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }

    [Required]
    [Display(Name = "Due date")]
    public DateTime DueDate { get; private set; }

    [Required]
    [Display(Name = "Emission Date")]
    public DateTime EmissionDate { get; private set; }

    [Display(Name = "Cancelled Date")]
    public DateTime? CancelledDate { get; private set; }

    [Display(Name = "Motive of cancellation")]
    [MinLength(5, ErrorMessage = "Motive of cancellation must be at least 5 characters long.")]
    [MaxLength(100, ErrorMessage = "Motive of cancellation must have maximum of 100 characters.")]
    public string? CancellationMotive { get; private set; }

    [Display(Name = "Paid Date")]
    public DateTime? PaidDate { get; private set; }

    [Key]
    [Display(Name = "Instalment number")]
    public int InstalmentNumber { get; private set; }

    [Required]
    [Column(TypeName = "decimal(10,2")]
    public decimal Value { get; private set; }

    [Column(TypeName = "decimal(10,2")]
    [Display(Name = "Paid value")]
    public decimal ValuePaid { get; private set; }

    public BillToReceive(int customerId, int saleId, int paymentMethodId, DateTime dueDate, DateTime emissionDate, DateTime? cancelledDate, string cancellationMotive,
        DateTime? paidDate, int instalmentNumber, decimal value, decimal valuePaid)
    {
        CustomerId = customerId;
        SaleId = saleId;
        PaymentMethodId = paymentMethodId;
        DueDate = dueDate;
        EmissionDate = emissionDate;
        CancelledDate = cancelledDate;
        CancellationMotive = cancellationMotive;
        PaidDate = paidDate;
        InstalmentNumber = instalmentNumber;
        Value = value;
        ValuePaid = valuePaid;
    }

    public void ConfigureCustomer(Customer customer)
    {
        Customer = customer;
    }

    public void ConfigureSale(Sale sale)
    {
        Sale = sale;
    }

    public void ConfigurePaymentMethod(PaymentMethod paymentMethod)
    {
        PaymentMethod = paymentMethod;
    }
}
