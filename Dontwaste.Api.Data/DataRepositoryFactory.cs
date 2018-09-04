using DontWaste.Api.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dontwaste.Api.Data
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        T IDataRepositoryFactory.GetDataRepository<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
