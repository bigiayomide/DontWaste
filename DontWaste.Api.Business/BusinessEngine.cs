using Dontwaste.Api.Data.Repositories;
using DontWaste.Api.Business.Contracts;
using DontWaste.Api.Core.Contracts;
using DontWaste.Api.Data.Contracts.IDataRepositories;
using System;

namespace DontWaste.Api.Business
{
    public class BusinessEngine: IBusinessEngine
    {
        IDataRepositoryFactory _DataRepositoryFactory;
        IUserRepository _UserRepository;
        public BusinessEngine(IDataRepositoryFactory dataRepositoryFactory, IUserRepository UserRepository)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _UserRepository = UserRepository;
        }
        public void Test()
        {
            var data=_DataRepositoryFactory.GetDataRepository<UserRepository>();
            _UserRepository.Get();
        }
    }
}
