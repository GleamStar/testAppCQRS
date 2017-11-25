using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ITestContext : IDisposable
    {
        /// <summary>
        /// Use for commands only
        /// </summary>
        /// <typeparam name="TEntity">Database entity</typeparam>
        /// <returns>Returns needed Set of objects from database</returns>
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : BaseEntity;

        /// <summary>
        /// Use for queries only
        /// </summary>
        /// <typeparam name="TEntity">Database entity</typeparam>
        /// <returns>Returns needed Set of objects from database</returns>
        IQueryable<TEntity> GetReadOnlyDbSet<TEntity>() where TEntity : BaseEntity;

        int Commit();

        Task<int> CommitAsync();
    }
}
