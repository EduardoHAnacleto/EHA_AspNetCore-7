using System.Composition.Convention;

namespace EHA_AspNetCore.Interfaces;

public interface IService<T> where T : class
{
    public T ProcessObject(T obj);

}
