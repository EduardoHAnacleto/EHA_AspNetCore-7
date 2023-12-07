using System.Composition.Convention;

namespace EHA_AspNetCore.Services.Interfaces;

public interface IService<T> where T : class
{
    public T ProcessObject(T obj);

    bool CheckIfForeignKey(int id);
}
