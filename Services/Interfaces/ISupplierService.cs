using EHA_AspNetCore.Models.People;

namespace EHA_AspNetCore.Services.Interfaces;

public interface ISupplierService : IService<Supplier>
{
    Task<string> ZipCodeAPI(string zipCode, string countryName);

    string RegexOnlyNumbers(string text);
}
