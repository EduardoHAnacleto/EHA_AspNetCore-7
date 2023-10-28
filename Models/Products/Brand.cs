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

[Table("Brands")]
public class Brand : Identification
{
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Brand name must be between 3 and 30 characters.")]
    public string Name { get; private set; }

    [ValidateNever]
    [StringLength(100)]
    public string UrlImage { get; private set; }

    public Brand(string name, string urlImage)
    {
        Name = name;
        UrlImage = urlImage;
    }

}
