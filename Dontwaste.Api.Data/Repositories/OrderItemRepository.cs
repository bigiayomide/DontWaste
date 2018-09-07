using DontWaste.Api.Data.Contracts.IDataRepositories;
using DontWaste.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dontwaste.Api.Data.Repositories
{
    public class OrderItemRepository : RepositoryService<OrderItem>, IOrderItemRepository
    {
        protected override OrderItem AddEntity(DontWasteContext entityContext, OrderItem entity)
        {
            return entityContext.OrderItems.Add(entity).Entity;
        }

        protected override IEnumerable<OrderItem> GetEntities(DontWasteContext entityContext)
        {
            return from e in entityContext.OrderItems
                   select e;
        }

        protected override OrderItem GetEntity(DontWasteContext entityContext, string id)
        {
            var query = (from e in entityContext.OrderItems
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        protected override OrderItem UpdateEntity(DontWasteContext entityContext, OrderItem entity)
        {
            return GetEntity(entityContext, entity.Id);
        }

        public DbSet<OrderItem> OrderItemDbSet(DontWasteContext entityContext)
        {
            return entityContext.OrderItems;
        }
    }
}
