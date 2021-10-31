using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Domain;
using VirtoCommerce.Platform.Security.Model;

namespace VirtoCommerce.Platform.Security.Repositories
{
    public class SecurityRepositoryStub : ISecurityRepository
    {
        public IQueryable<UserApiKeyEntity> UserApiKeys => Array.Empty<UserApiKeyEntity>().AsQueryable();

        public IQueryable<UserPasswordHistoryEntity> UserPasswordsHistory => Array.Empty<UserPasswordHistoryEntity>().AsQueryable();

        public IUnitOfWork UnitOfWork => new UnitOfWorkStub();

        public void Add<T>(T item) where T : class
        {
           //Nothing todo
        }

        public void Attach<T>(T item) where T : class
        {
            //Nothing todo
        }

        public void Dispose()
        {
            //Nothing todo
        }

        public Task<IEnumerable<UserPasswordHistoryEntity>> GetUserPasswordsHistoryAsync(string userId, int passwordsCountToCheck)
        {
            return Task.FromResult(Enumerable.Empty<UserPasswordHistoryEntity>());
        }

        public void Remove<T>(T item) where T : class
        {
            //Nothing todo
        }

        public void Update<T>(T item) where T : class
        {
            //Nothing todo
        }
    }
}
