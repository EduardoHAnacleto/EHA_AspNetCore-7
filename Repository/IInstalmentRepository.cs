using EHA_AspNetCore.Models.Payments;

namespace EHA_AspNetCore.Repository;

public interface IInstalmentRepository : IRepository<Instalment>
{
    void Save();
}
