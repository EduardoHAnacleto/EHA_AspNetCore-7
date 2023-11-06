using EHA_AspNetCore.Repository.IRepository;
using EHA_AspNetCore_Angular.Data;
using EHA_AspNetCore_Angular.Models.Products;

namespace EHA_AspNetCore.Repository;

public class BrandRepository : Repository<Brand>, IBrandRepository
{
    private AppDbContext _db;

    public BrandRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void Save()
    {
        _db.SaveChanges();
    }

    public void Update(Brand obj)
    {
        _db.Brands.Update(obj);
    }
}
