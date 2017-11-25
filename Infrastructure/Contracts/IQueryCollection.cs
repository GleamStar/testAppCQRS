using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IQueryCollection<TEntity>
    {
        Task<IEnumerable<TEntity>> ExecuteAsync(TestContext context);
    }
}
