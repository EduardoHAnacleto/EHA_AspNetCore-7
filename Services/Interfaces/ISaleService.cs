using EHA_AspNetCore.Models.Sales;

namespace EHA_AspNetCore.Services.Interfaces;

public interface ISaleService : IService<Sale>
{
    Task<ItemSale> PopulateItemSaleProductFromId(int id);
}
