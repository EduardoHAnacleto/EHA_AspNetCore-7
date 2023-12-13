using EHA_AspNetCore.Models.Enums;
using EHA_AspNetCore_Angular.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EHA_AspNetCore.Models.Abstractions;

public abstract class Person : Identification
{
    [Required(ErrorMessage = "Name must be informed.")]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "Name must be between 8 and 30 characters.")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Gender")]
    [Column(TypeName = "nvarchar(20)")]
    public GenderEnum Gender { get; set; }

    [Display(Name = "Date of birth")]
    public DateTime? DateOfBirth { get; set; }

    [Required(ErrorMessage = "E-mail must be informed.")]
    [Display(Name = "E-mail")]
    [MaxLength(40, ErrorMessage = "E-mail must have maximum of 40 characters.")]
    [EmailAddress]
    public string Email { get; set; }

    [Display(Name = "Street name")]
    [StringLength(30, MinimumLength = 10, ErrorMessage = "Name must be between 10 and 30 characters.")]
    public string Street { get; set; }

    [Display(Name = "District")]
    [StringLength(50, MinimumLength = 8, ErrorMessage = "District must be between 8 and 50 characters.")]
    public string District { get; set; }

    [Display(Name = "Building number")]
    [StringLength(50, MinimumLength = 0, ErrorMessage = "Building number must be between 3 and 50 characters.")]
    public string BuildingNumber { get; set; }

    [Display(Name = "Address addition")]
    [MaxLength(15, ErrorMessage = "Address addition have maximum characters.")]
    public string AddressAddition { get; set; }

    [Display(Name = "Zip code")]
    [MaxLength(20, ErrorMessage = "Zip code must have maximum of 20 characters.")]
    public string ZipCode { get; set; }

    [Display(Name = "City")]
    [MaxLength(50, ErrorMessage = "City must have maximum of 50 characters.")]
    public string City { get; set; }

    [Display(Name = "Country")]
    [MaxLength(50, ErrorMessage = "Country must have maximum of 50 characters.")]
    public string Country { get; set; }

    [Required(ErrorMessage = "Phone number must be informed.")]
    [Display(Name = "Phone number")]
    [StringLength(15, MinimumLength = 8, ErrorMessage = "Phone number must be between 8 and 15 characters.")]
    public string PhoneNumber { get; set; }

    public Person()
    {
        
    }

    public Person(string name, GenderEnum gender, DateTime dateOfBirth, string email, string street, string district,
        string buildingNumber, string addressAddition, string zipCode, string city, string country, string phoneNumber)
    {
        Name = name;
        Gender = gender;
        DateOfBirth = dateOfBirth;
        Email = email;
        Street = street;
        District = district;
        BuildingNumber = buildingNumber;
        AddressAddition = addressAddition;
        ZipCode = zipCode;
        City = city;
        Country = country;
        PhoneNumber = phoneNumber;
    }
}
