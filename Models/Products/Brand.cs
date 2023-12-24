using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHA_AspNetCore.Models.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace EHA_AspNetCore.Models.Products;

[Table("Brands")]
public class Brand : Identification
{
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Brand name must be between 3 and 30 characters.")]
    public string Name { get; set; }

    [ValidateNever]
    [StringLength(100)]
    public string UrlImage { get; set; }

    public Brand()
    {
        
    }

    public Brand(string name, string urlImage)
    {
        Name = name;
        UrlImage = urlImage;
    }

}
