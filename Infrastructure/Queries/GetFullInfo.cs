using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Queries
{
    public class GetFullInfo: IQueryCollection<Classes>
    {
        public async Task<IEnumerable<Classes>> ExecuteAsync(TestContext context)
        {
            return await context.Classes.Include(c => c.Students).ToListAsync();
        }
    }
}
