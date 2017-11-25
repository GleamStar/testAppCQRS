using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Contracts;

namespace Infrastructure
{
    public class Executor : IExecutor
    {
        private readonly TestContext _context;

        public Executor(TestContext context)
        {
            _context = context;
        }
        public async Task<T> QueryAsync<T>(IQuery<T> query)
        {
            return await query.ExecuteAsync(_context);
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(IQueryCollection<T> query)
        {
            return await query.ExecuteAsync(_context);
        }

        public async Task<T> ExecuteAsync<T>(ICommand<T> command)
        {
            command.Validate();
            return await command.ExecuteAsync(_context);
        }
    }
}
