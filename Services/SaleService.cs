using EHA_AspNetCore.Models.Sales;
using EHA_AspNetCore.Services.Interfaces;

namespace EHA_AspNetCore.Services;

public class SaleService : ISaleService
{
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
