using EHA_AspNetCore.Models.Payments;

namespace EHA_AspNetCore.Services.Interfaces;

public interface IPaymentConditionService : IService<PaymentCondition>
{
    PaymentCondition PopulateFullObject(PaymentCondition paymentCondition);

    Task<PaymentCondition> GetFirstOrDefaultPaymentCondition(CancellationToken cancellationToken = default);
}
