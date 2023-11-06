using EHA_AspNetCore_Angular.Models.Products;

namespace EHA_AspNetCore.Repository;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category obj);
    void Save();
}
