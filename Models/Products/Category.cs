using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHA_AspNetCore_Angular.Models.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EHA_AspNetCore_Angular.Models.Products;

[Table("Categories")]
public class Category : Identification
{
    [Required]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Brand name must be between 3 and 30 characters.")]
    public string Name { get; set; }

    [MaxLength(50, ErrorMessage = "Description must have maximum of 50 characters.")]
    public string Description { get; set; }

    [Display(Name = "Display order")]
    public int DisplayOrder { get; set; }

    [ValidateNever]
    [StringLength(100)]
    public string UrlImage { get; private set; }

    public Category()
    {
        
    }

    public Category(string name, string description, int displayOrder, string urlImage)
    {
        Name = name;
        Description = description;
        DisplayOrder = displayOrder;
        UrlImage = urlImage;
    }
}
