using EHA_AspNetCore.Interfaces;
using EHA_AspNetCore_Angular.Data;
using EHA_AspNetCore_Angular.Models.Products;

namespace EHA_AspNetCore.Services;

public class BrandService : IBrandService
{

    public BrandService()
    {
        
    }

    public Brand ProcessObject(Brand obj)
    {
        return obj;
    }
}
