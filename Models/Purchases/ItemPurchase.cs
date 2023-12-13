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
    public int PurchaseBillModel { get; set; }

    [Key]
    [Display(Name = "Bill number")]
    public int PurchaseBillNumber { get; set; }

    [Key]
    [Display(Name = "Bill series")]
    public int PurchaseBillSeries { get; set; }

    [Key]
    [Display(Name = "Supplier")]
    public int PurchaseSupplierId { get; set; }
   // public Supplier Supplier { get; private set; }


    [Display(Name = "Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }

    [Required]
    [Display(Name = "Discount percent")]
    [Column(TypeName = "decimal(5,2")]
    [DefaultValue(0)]
    public decimal Discount { get; set; }

    [Required]
    [Display(Name = "Value")]
    [Column(TypeName = "decimal(10,2")]
    public decimal ProductValue { get; set; }

    [Display(Name = "Cancelled Date")]
    public DateTime? CancelledDate { get; set; }
}
