using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Models.Products;

namespace EHA_AspNetCore.Services.Interfaces;

public interface IProductService : IService<Product>
{
    Task<Product> GetFullObject(int id);
}
