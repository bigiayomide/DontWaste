using DontWaste.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DontWaste.Api.Data.Contracts.IDataRepositories;

namespace Dontwaste.Api.Data.Repositories
{
    public class OrderRepository : RepositoryService<Order>, IOrderRepository
    {
        protected override Order AddEntity(DontWasteContext entityContext, Order entity)
        {
            return entityContext.Orders.Add(entity).Entity;
        }

        protected override IEnumerable<Order> GetEntities(DontWasteContext entityContext)
        {
            return from e in entityContext.Orders
                   select e;
        }

        protected override Order GetEntity(DontWasteContext entityContext, string id)
        {
            var query = (from e in entityContext.Orders
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        protected override Order UpdateEntity(DontWasteContext entityContext, Order entity)
        {
            return GetEntity(entityContext, entity.Id);
        }

        public DbSet<Order> GetOrderDbSet(DontWasteContext entityContext)
        {
            return entityContext.Orders;
        }
    }
}
