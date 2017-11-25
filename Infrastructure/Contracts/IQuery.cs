using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface IQuery<T>
    {
        Task<T> ExecuteAsync(TestContext context);
    }
}
