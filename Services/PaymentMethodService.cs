using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Services.Interfaces;
using EHA_AspNetCore.Data;

namespace EHA_AspNetCore.Services;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly AppDbContext _context;

    public PaymentMethodService(AppDbContext context)
    {
        _context = context;
    }

    public bool CheckIfForeignKey(int id)
    {
        return _context.Instalments.Any(i => i.PaymentMethod.Id == id || i.PaymentMethodId == id);
    }

    public Task<ICollection<PaymentMethod>> GetAll()
    {
        throw new NotImplementedException();
    }

    public PaymentMethod ProcessObject(PaymentMethod obj)
    {
        throw new NotImplementedException();
    }
}
