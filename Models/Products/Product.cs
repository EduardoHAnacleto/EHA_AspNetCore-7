using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHA_AspNetCore_Angular.Models.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EHA_AspNetCore_Angular.Models.Products;

[Table("Products")]
public class Product : Identification
{
    [Required(ErrorMessage = "Product name must be informed.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Product value")]
    [Column(TypeName = "decimal(10,2")]
    [Range(0, 1000, ErrorMessage = "Value range is between 0 and 1000")]
    //[DefaultValue(0)]
    public decimal Value { get; set; }

    [Required]
    [Display(Name = "Product cost")]
    [Column(TypeName = "decimal(10,2")]
    [Range(0, 1000, ErrorMessage = "Cost range is between 0 and 1000")]
    //[DefaultValue(0)]
    public decimal Cost { get; set; }

    [Range(0,int.MaxValue, ErrorMessage ="Stock has a minimum of 0")]
    //[DefaultValue(0)]
    public int Stock { get; set; }

    [StringLength(30)]
    public string Barcode { get; set; }

    [ValidateNever]
    [StringLength(100)]
    public string ImageUrl { get; set; }

    [ValidateNever]
    [StringLength(100)]
    public string ImageThumbnailUrl { get; set; }

    [Required]
    [StringLength(5, MinimumLength = 2, ErrorMessage = "UND must be between 2 and 5 characters.")]
    [Display(Name = "Unit of Measurement")]
    public string Unit{ get; set; }

    public int BrandId { get; set; }
    public Brand Brand { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public Product()
    {
        
    }

    public Product(string name, decimal value, int stock, string barcode, string unit)
    {
        Name = name;
        Value = value;
        Stock = stock;
        Barcode = barcode;
        Unit = unit;
    }

    public void ConfigureBrand(Brand brand)
    {
        Brand = brand;
    }

    public void ConfigureCategory(Category category)
    {
        Category = category;
    }
}
