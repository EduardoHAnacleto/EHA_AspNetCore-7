using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Services.Interfaces;
using EHA_AspNetCore_Angular.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EHA_AspNetCore.Services;

public class PaymentConditionService : IPaymentConditionService
{
    private readonly AppDbContext _context;

    public PaymentConditionService(AppDbContext context)
    {
        _context = context;
    }

    public bool CheckIfForeignKey(int id)
    {
        throw new NotImplementedException();
    }

    public PaymentCondition PopulateFullObject(PaymentCondition paymentCondition)
    {
        paymentCondition.InstalmentList = _context.Instalments.Where(p => p.PaymentConditionId == paymentCondition.Id).ToList();
        foreach (var instalment in paymentCondition.InstalmentList)
        {
            instalment.PaymentMethod = _context.PaymentMethods.FirstOrDefault(p => p.Id == instalment.PaymentMethodId);
        }
        return paymentCondition;
    }

    public PaymentCondition ProcessObject(PaymentCondition obj)
    {
        throw new NotImplementedException();
    }

    public async Task<PaymentCondition> GetFirstOrDefaultPaymentCondition(CancellationToken cancellationToken = default)
    {
        var pcTask = _context.PaymentConditions
            .Include(x => x.InstalmentList)
            .ThenInclude(y => y.PaymentMethod)
            .FirstOrDefaultAsync(cancellationToken);
        var pc = await pcTask;

        return pc;
    }

}
