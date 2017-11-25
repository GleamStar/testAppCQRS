using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface ITestContext
    {
        Task<bool> CommitAsync();
    }
}
