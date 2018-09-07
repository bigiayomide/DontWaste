using DontWaste.Api.Core.Contracts;
using DontWaste.Api.Data.Contracts.IDataRepositories;
using DontWaste.Api.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Entity;

namespace Dontwaste.Api.Data.Repositories
{
    public class UserRepository : RepositoryService<AppUser>, IUserRepository
    {
        protected override AppUser AddEntity(DontWasteContext entityContext, AppUser entity)
        {
            return entityContext.Users.Add(entity).Entity;
        }

        protected override IEnumerable<AppUser> GetEntities(DontWasteContext entityContext)
        {
            return from e in entityContext.Users
                   select e;
        }

        protected override AppUser GetEntity(DontWasteContext entityContext, string id)
        {
            var query = (from e in entityContext.Users
                         where e.Id == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        protected override AppUser UpdateEntity(DontWasteContext entityContext, AppUser entity)
        {
            return (from e in entityContext.Users
                    where e.Id == entity.Id
                    select e).FirstOrDefault();
        }

        public void CreateOrder(Order order, string UserId)
        {
            using (DontWasteContext entityContext = new DontWasteContext())
            {
                AppUser user = GetEntity(entityContext, UserId);
                user.Orders.Add(order);
                entityContext.SaveChanges();
            }
        }

    }
}
