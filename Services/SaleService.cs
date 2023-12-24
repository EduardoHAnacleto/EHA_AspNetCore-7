using EHA_AspNetCore.Models.Sales;
using EHA_AspNetCore.Services.Interfaces;
using EHA_AspNetCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EHA_AspNetCore.Services;

public class SaleService : ISaleService
{
    private readonly AppDbContext _context;

    public SaleService(AppDbContext context)
    {
        _context = context;
    }

    public bool CheckIfForeignKey(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Sale>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<ItemSale> PopulateItemSaleProductFromId(int id)
    {
        var isTask = _context.ItemsSale
            .Include(x => x.Product)
            .FirstOrDefaultAsync(x => x.ItemSaleId == id);
        var pc = await isTask;
        return pc;
    }

    public Sale ProcessObject(Sale obj)
    {
        ProcessProductStock(obj);
        ProcessBillsToReceive(obj);
        return obj;
    }

    private void ProcessBillsToReceive(Sale obj)
    {
        throw new NotImplementedException();
    }

    private void ProcessProductStock(Sale obj)
    {
        foreach (var product in obj.SaleItemsList)
        {

        }
    }
}
