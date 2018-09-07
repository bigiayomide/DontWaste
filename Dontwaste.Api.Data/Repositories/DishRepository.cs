using DontWaste.Api.Data.Contracts.IDataRepositories;
using DontWaste.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dontwaste.Api.Data.Repositories
{
    public class DishRepository : RepositoryService<Dish>, IDishRepository
    {
        protected override Dish AddEntity(DontWasteContext entityContext, Dish entity)
        {
            return entityContext.Dishes.Add(entity).Entity;
        }

        protected override IEnumerable<Dish> GetEntities(DontWasteContext entityContext)
        {
            return from e in entityContext.Dishes
                   select e;
        }

        protected override Dish GetEntity(DontWasteContext entityContext, string id)
        {
            var query = (from e in entityContext.Dishes
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        protected override Dish UpdateEntity(DontWasteContext entityContext, Dish entity)
        {
            return GetEntity(entityContext, entity.Id);
        }

        public DbSet<Dish> DishDbSet(DontWasteContext entityContext)
        {
            return entityContext.Dishes;
        }
    }
}
