using EHA_AspNetCore.Data;
using EHA_AspNetCore.Models.Products;
using EHA_AspNetCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace EHA_AspNetCore.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public bool CheckIfForeignKey(int id)
    {
        throw new NotImplementedException();
    }

    public Product ProcessObject(Product obj)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Product>> GetAll()
    {
        var getAllTask = _context.Products
            .Include(x => x.Brand)
            .Include(y => y.Category)
            .ToListAsync();
        var allObjs = await getAllTask;

        return allObjs;
    }
}
