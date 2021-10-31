using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Platform.Core.Domain
{
    public class UnitOfWorkStub : IUnitOfWork
    {
        public int Commit()
        {
            return 0;
        }

        public Task<int> CommitAsync()
        {
            return Task.FromResult(0);
        }

    }
}
