using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Models.People;
using EHA_AspNetCore.Models.Purchases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Bills;

[Table("BillsToPay")]
public class BillToPay
{

    [Key]
    [Required]
    [Display(Name = "Bill number")]
    public int BillNumber { get; private set; }

    [Key]
    [Required]
    [Display(Name = "Bill model")]
    public int BillModel { get; private set; }

    [Key]
    [Required]
    [Display(Name = "Bill series")]
    public int BillSeries { get; private set; }

    [Key]
    [Required]
    public int SupplierId { get; private set; }
    public Supplier Supplier { get; private set; }

    [Key]
    [Required]
    [Display(Name = "Instalment number")]
    public int InstalmentNumber { get; private set; }

    [Required]
    [Display(Name = "Emission Date")]
    public DateTime EmissionDate { get; private set; }

    [Required]
    [Display(Name = "Due Date")]
    public DateTime DueDate { get; private set; }

    [Display(Name = "Paid Date")]
    public DateTime? PaidDate { get; private set; }

    [Display(Name = "Cancelled Date")]
    public DateTime? CancelledDate { get; private set; }

    [Display(Name = "Motive of cancellation")]
    [MinLength(5, ErrorMessage = "Motive of cancellation must be at least 5 characters long.")]
    [MaxLength(100, ErrorMessage = "Motive of cancellation must have maximum of 100 characters.")]
    public string? CancellationMotive { get; private set; }

    [Required]
    [Display(Name = "Payment Method")]
    public int PaymentMethodId { get; private set; }
    public PaymentMethod PaymentMethod { get; private set; }

    [Display(Name = "Purchase")]
    public int PurchaseId { get; private set; }
    public Purchase? Purchase { get; private set; }

    [Required]
    [Column(TypeName = "decimal(10,2")]
    public decimal Value { get; private set; }

    [Column(TypeName = "decimal(10,2")]
    [Display(Name = "Paid value")]
    public decimal ValuePaid { get; private set; }

    public BillToPay(int billNumber, int billModel, int billSeries, int supplierId, int instalmentNumber, DateTime emissionDate,
    DateTime dueDate, DateTime? paidDate, DateTime? cancelledDate, string cancellationMotive, int paymentMethodId, int purchaseId, decimal value, decimal valuePaid)
    {
        BillNumber = billNumber;
        BillModel = billModel;
        BillSeries = billSeries;
        SupplierId = supplierId;
        InstalmentNumber = instalmentNumber;
        EmissionDate = emissionDate;
        DueDate = dueDate;
        PaidDate = paidDate;
        CancelledDate = cancelledDate;
        CancellationMotive = cancellationMotive;
        PaymentMethodId = paymentMethodId;
        PurchaseId = purchaseId;
        Value = value;
        ValuePaid = valuePaid;
    }

    public void ConfigureSupplier(Supplier supplier)
    {
        Supplier = supplier;
    }

    public void ConfigurePaymentMethod(PaymentMethod paymentMethod)
    {
        PaymentMethod = paymentMethod;
    }

    public void ConfigurePurchase(Purchase purchase)
    {
        Purchase = purchase;
    }
}
