using System;
using System.Collections.Generic;
using System.Text;

namespace DontWaste.Api.Core.Contracts
{
    public interface IDataRepositoryFactory
    {
        T GetDataRepository<T>() where T : IDataRepository;
    }
}
