using EHA_AspNetCore.Services.Interfaces;
using EHA_AspNetCore_Angular.Data;
using EHA_AspNetCore_Angular.Models.Products;

namespace EHA_AspNetCore.Services;

public class BrandService : IBrandService
{
    private readonly AppDbContext _context;

    public BrandService(AppDbContext context)
    {
        _context = context;
    }

    public bool CheckIfForeignKey(int id)
    {
        return _context.Products.Any(i => i.Brand.Id == id || i.BrandId == id);
    }

    public Brand ProcessObject(Brand obj)
    {
        return obj;
    }
}
