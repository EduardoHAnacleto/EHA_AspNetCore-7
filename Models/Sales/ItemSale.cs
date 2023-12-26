using EHA_AspNetCore.Models.Base;
using EHA_AspNetCore.Models.Products;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Sales;

[Table("ItemsSale")]
public class ItemSale
{
    [Key]
    [Display(Name = "Sale ID")]
    public int ItemSaleId { get; set; }

    [Key]
    [Display(Name = "Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Required]
    [Range(0, 10000)]
    public int Quantity { get; set; }

    [Required]
    [Display(Name = "Discount percentage")]
    [DefaultValue(0)]
    [Range(0, 20000)]
    public int Discount { get; set; }

    [Required]
    [Display(Name = "Value")]
    [Column(TypeName = "decimal(10,2")]
    [Range(0, 20000)]
    public decimal ProductValue { get; set; }

    [Display(Name = "Cancelled Date")]
    public DateTime? CancelledDate { get; set; }

    public ItemSale()
    {
        
    }

    public ItemSale(int quantity, int discount, decimal productValue, DateTime? cancelledDate)
    {
        Quantity = quantity;
        Discount = discount;
        ProductValue = productValue;
        CancelledDate = (DateTime)cancelledDate;
    }

    public void ConfigureProduct(Product product)
    {
        Product = product;
    }
}
