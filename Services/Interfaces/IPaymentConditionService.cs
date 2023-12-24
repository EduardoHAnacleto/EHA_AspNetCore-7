using EHA_AspNetCore.Models.Payments;
using Microsoft.AspNetCore.Mvc;

namespace EHA_AspNetCore.Services.Interfaces;

public interface IPaymentConditionService : IService<PaymentCondition>
{
    PaymentCondition PopulateFullObject(PaymentCondition paymentCondition);

    Task<PaymentCondition> GetFirstOrDefaultPaymentCondition(CancellationToken cancellationToken = default);

    Task<ICollection<Instalment>> GetInstalments(int id);

    Task<PaymentCondition> PopulateFullObjectFromId(int id);

}
