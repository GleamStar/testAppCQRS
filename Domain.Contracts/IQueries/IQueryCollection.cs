using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IQueryCollection<TEntity>
    {
        Task<IEnumerable<TEntity>> ExecuteAsync(ITestContext context);
    }
}
