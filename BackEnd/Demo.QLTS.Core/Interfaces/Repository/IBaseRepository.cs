using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.QLTS.Core.Interfaces.Repository
{
    public interface IBaseRepository<TEntity>
    {
        public Task<List<T>> QueryUsingStoredProcedure<T>(string storeName, object param);

        public Task<int> ExecuteUsingStoredProcedure(string storeName, object param);
    }
}
