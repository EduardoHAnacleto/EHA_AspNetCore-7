using EHA_AspNetCore_Angular.Models.Products;

namespace EHA_AspNetCore.Repository;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product product);
    void Save();
}
