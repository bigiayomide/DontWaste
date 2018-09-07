using DontWaste.Api.Core.Contracts;
using DontWaste.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DontWaste.Api.Data.Contracts.IDataRepositories
{
    public interface ICategoryRepository:IDataRepository<Category>
    {
        DbSet<Category> CategoryDbSet(DontWasteContext entityContext);
    }
}
