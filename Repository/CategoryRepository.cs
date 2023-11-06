using EHA_AspNetCore.Repository.IRepository;
using EHA_AspNetCore_Angular.Data;
using EHA_AspNetCore_Angular.Models.Products;
using System.Linq.Expressions;

namespace EHA_AspNetCore.Repository;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    private readonly AppDbContext _db;

    public CategoryRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void Save()
    {
        _db.SaveChanges();
    }

    public void Update(Category obj)
    {
        _db.Categories.Update(obj);
    }
}
