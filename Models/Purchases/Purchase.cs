using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Models.People;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Purchases;

[Table("Purchases")]
public class Purchase
{

    [Key]
    [Display(Name = "Bill model")]
    public int BillModel { get; set; }

    [Key]
    [Display(Name = "Bill number")]
    public int BillNumber { get; set; }

    [Key]
    [Display(Name = "Bill series")]
    public int BillSeries { get; set; }

    [Key]
    [Display(Name = "Supplier")]
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    [Display(Name = "Cancellation date")]
    public DateTime? CancellationDate { get; set; }

    [Display(Name = "Motive of cancellation")]
    [MinLength(5, ErrorMessage = "Motive of cancellation must be at least 5 characters long.")]
    [MaxLength(100, ErrorMessage = "Motive of cancellation must have maximum of 100 characters.")]
    public string? CancellationMotive { get; set; }

    [Required]
    [Display(Name = "Emission date")]
    public DateTime EmissionDate { get; set; }

    [Required]
    [Display(Name = "Payment condition")]
    public int PaymentConditionId { get; set; }
    public PaymentCondition PaymentCondition { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2")]
    public decimal Value { get; set; }

    [Required]
    [DefaultValue(0)]
    [Display(Name = "Freight cost")]
    [Column(TypeName = "decimal(10,2")]
    public decimal FreightValue { get; set; }

    [Required]
    [DefaultValue(0)]
    [Display(Name = "Extra expenses")]
    [Column(TypeName = "decimal(10,2")]
    public decimal ExtraExpenses { get; set; }

    [Required]
    [DefaultValue(0)]
    [Display(Name = "Insurance value")]
    [Column(TypeName = "decimal(10,2")]
    public decimal InsuranceValue { get; set; }

    [Required]
    public ICollection<ItemPurchase> ItemPurchaseList { get; set; } = new List<ItemPurchase>();

    public Purchase()
    {
        
    }

    public Purchase(int billModel, int billNumber, int billSeries, int supplierId, DateTime? cancellationDate,
    string cancellationMotive, DateTime emissionDate, int paymentConditionId,
    decimal value, decimal freightValue, decimal extraExpenses, decimal insuranceValue)
    {
        BillModel = billModel;
        BillNumber = billNumber;
        BillSeries = billSeries;
        SupplierId = supplierId;
        CancellationDate = cancellationDate;
        CancellationMotive = cancellationMotive;
        EmissionDate = emissionDate;
        PaymentConditionId = paymentConditionId;
        Value = value;
        FreightValue = freightValue;
        ExtraExpenses = extraExpenses;
        InsuranceValue = insuranceValue;
    }

    public void ConfigurePaymentCondition(PaymentCondition paymentCondition)
    {
        PaymentCondition = paymentCondition;
    }

    public void ConfigureSupplier(Supplier supplier)
    {
        Supplier = supplier;
    }

    public void ConfigureItemPurchaseList(List<ItemPurchase> itemPurchaseList)
    {
        ItemPurchaseList = itemPurchaseList;
    }
}
