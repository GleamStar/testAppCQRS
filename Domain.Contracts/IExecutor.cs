using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IExecutor
    {

        Task<IEnumerable<T>> QueryAsync<T>(IQueryCollection<T> query);

        Task<T> ExecuteAsync<T>(ICommand<T> command);
    }
}