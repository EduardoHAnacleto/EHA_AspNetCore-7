using EHA_AspNetCore_Angular.Models.Products;
using System.Linq.Expressions;

namespace EHA_AspNetCore.Repository;

public interface IBrandRepository : IRepository<Brand>
{
    void Update(Brand obj);
    void Save();
}
