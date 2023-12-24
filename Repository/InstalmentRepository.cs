using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Repository.IRepository;
using EHA_AspNetCore.Data;

namespace EHA_AspNetCore.Repository;

public class InstalmentRepository : Repository<Instalment>, IInstalmentRepository
{
    private readonly AppDbContext _db;

    public InstalmentRepository(AppDbContext db) : base(db)
    {
        _db = db;
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
