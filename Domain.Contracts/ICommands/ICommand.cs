using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ICommand<T>
    {

        Task<T> ExecuteAsync(ITestContext context);

        void Validate();
    }
}
