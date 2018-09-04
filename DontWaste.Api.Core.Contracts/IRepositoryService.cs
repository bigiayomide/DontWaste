using System;
using System.Collections.Generic;

namespace DontWaste.Api.Core.Contracts
{
    public interface IRepositoryService<T> where T : class
    {
        T Add(T entity);

        void Remove(T entity);

        void Remove(string id);

        T Update(T entity);

        IEnumerable<T> Get();

        T Get(string id);

    }
}
