using EHA_AspNetCore.Repository.IRepository;
using EHA_AspNetCore_Angular.Data;
using EHA_AspNetCore_Angular.Models.Products;

namespace EHA_AspNetCore.Repository;

public class ProductRepository : Repository<Product>, IProductRepository
{
    private AppDbContext _db;

    public ProductRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }
    public void Save()
    {
        _db.SaveChanges();
    }

    public void Update(Product obj)
    {
        _db.Products.Update(obj);
    }
}
