using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public abstract class CommandBase<T> : ICommand<T>
    {
        public virtual void Validate()
        { 
        }

        public virtual Task<T> ExecuteAsync(TestContext context)
        {
            throw new NotImplementedException("CommandBase didn't implement ExecuteAsync method.");
        }

        protected CommandResult GetSuccessResult()
        {
            return new CommandResult
            {
                Success = true
            };
        }
    }
}
