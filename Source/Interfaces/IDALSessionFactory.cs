using System.Collections.Generic;

namespace ServiceInterfaces
{
    public interface IDALSessionFactory
    {
        IDictionary<string, T> CreateSessionFactory<T>();
    }
}
