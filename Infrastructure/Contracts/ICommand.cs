using System.Threading.Tasks;

namespace Infrastructure
{
    public interface ICommand<T>
    {
        Task<T> ExecuteAsync(TestContext context);

        void Validate();
    }
}
