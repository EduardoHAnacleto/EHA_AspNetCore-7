using System.Composition.Convention;

namespace EHA_AspNetCore.Services.Interfaces;

public interface IService<T> where T : class
{
    public T ProcessObject(T obj);

    public Task<ICollection<T>> GetAll();

    bool CheckIfForeignKey(int id);
}
