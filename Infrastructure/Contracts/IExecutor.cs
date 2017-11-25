using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Contracts;

namespace Infrastructure
{
    public interface IExecutor
    {
        Task<T> QueryAsync<T>(IQuery<T> query);

        Task<IEnumerable<T>> QueryAsync<T>(IQueryCollection<T> query);

        Task<T> ExecuteAsync<T>(ICommand<T> command);
    }
}