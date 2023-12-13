using EHA_AspNetCore.Models.People;

namespace EHA_AspNetCore.Services.Interfaces;

public interface ICustomerService : IService<Customer>
{
    Task<string> ZipCodeAPI(string zipCode, string countryName);

    string RegexOnlyNumbers(string text);
}
