using DontWaste.Api.Core.Contracts;
using DontWaste.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DontWaste.Api.Data.Contracts.IDataRepositories
{
    public interface IOrderRepository: IDataRepository<Order>
    {
        DbSet<Order> GetOrderDbSet(DontWasteContext entityContext);
    }
}
