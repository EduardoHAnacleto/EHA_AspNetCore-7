using EHA_AspNetCore.Models.People;
using EHA_AspNetCore_Angular.Models.Products;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Purchases;

[Table("PurchasesSale")]
public class ItemPurchase
{
    [Key]
    [Display(Name = "Bill model")]
    public int PurchaseBillModel { get; private set; }

    [Key]
    [Display(Name = "Bill number")]
    public int PurchaseBillNumber { get; private set; }

    [Key]
    [Display(Name = "Bill series")]
    public int PurchaseBillSeries { get; private set; }

    [Key]
    [Display(Name = "Supplier")]
    public int PurchaseSupplierId { get; private set; }
   // public Supplier Supplier { get; private set; }


    [Display(Name = "Product")]
    public int ProductId { get; private set; }
    public Product Product { get; private set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; private set; }

    [Required]
    [Display(Name = "Discount percent")]
    [Column(TypeName = "decimal(5,2")]
    [DefaultValue(0)]
    public decimal Discount { get; private set; }

    [Required]
    [Display(Name = "Value")]
    [Column(TypeName = "decimal(10,2")]
    public decimal ProductValue { get; private set; }

    [Display(Name = "Cancelled Date")]
    public DateTime? CancelledDate { get; private set; }
}
