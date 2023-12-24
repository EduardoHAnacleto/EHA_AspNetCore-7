using EHA_AspNetCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EHA_AspNetCore.Repository.IRepository;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _db;
    internal DbSet<T> DbSet { get; set; }

    public Repository(AppDbContext db)
    {
        _db = db;
        this.DbSet = _db.Set<T>();
    }

    public void Add(T entity)
    {
        DbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        DbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        DbSet.RemoveRange(entities);
    }

    public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
    {
        IQueryable<T> query = DbSet;
        query = query.Where(filter);
        return query.FirstOrDefault();
    }

    public IEnumerable<T> GetAll()
    {
        IQueryable<T> query = DbSet;
        return query.ToList();
    }
}
