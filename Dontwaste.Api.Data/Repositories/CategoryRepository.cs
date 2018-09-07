using DontWaste.Api.Data.Contracts.IDataRepositories;
using DontWaste.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Dontwaste.Api.Data.Repositories
{
    public class CategoryRepository : RepositoryService<Category>, ICategoryRepository
    {
        protected override Category AddEntity(DontWasteContext entityContext, Category entity)
        {
            return entityContext.Categories.Add(entity).Entity;
        }

        protected override IEnumerable<Category> GetEntities(DontWasteContext entityContext)
        {
            return from e in entityContext.Categories
                   select e;
        }

        protected override Category GetEntity(DontWasteContext entityContext, string id)
        {
            var query = (from e in entityContext.Categories
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        protected override Category UpdateEntity(DontWasteContext entityContext, Category entity)
        {
            return GetEntity(entityContext, entity.Id);
        }

        public DbSet<Category> CategoryDbSet(DontWasteContext entityContext)
        {
            return entityContext.Categories;
        }
    }
}
