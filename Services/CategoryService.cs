using EHA_AspNetCore.Repository;
using EHA_AspNetCore_Angular.Models.Products;
using System.Linq.Expressions;

namespace EHA_AspNetCore.Services;

public class CategoryService : ICategoryRepository
{
    public void Add(Category entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Category entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(IEnumerable<Category> entities)
    {
        throw new NotImplementedException();
    }

    public Category Get(Expression<Func<Category, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void Update(Category obj)
    {
        throw new NotImplementedException();
    }
}
