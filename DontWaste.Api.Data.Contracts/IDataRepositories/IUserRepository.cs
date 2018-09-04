using DontWaste.Api.Core.Contracts;
using DontWaste.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DontWaste.Api.Data.Contracts.IDataRepositories
{
    public interface IUserRepository:IDataRepository<AppUser>
    {
    }
}
