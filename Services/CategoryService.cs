using EHA_AspNetCore.Repository;
using EHA_AspNetCore.Services.Interfaces;
using EHA_AspNetCore_Angular.Data;
using EHA_AspNetCore_Angular.Models.Products;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EHA_AspNetCore.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public bool CheckIfForeignKey(int id)
    {
        return _context.Products.Any(i => i.CategoryId == id || i.Category.Id == id);
    }

    public Category ProcessObject(Category obj)
    {
        throw new NotImplementedException();
    }
}
