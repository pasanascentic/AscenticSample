using Ascentic.Sample.Repositories.EntityRepositories;
using System.Threading.Tasks;

namespace Ascentic.Sample.Repositories
{
    public interface IUnitOfWork
    {
        INewsRepository News { get; }
        Task<int> Commit();
    }
}
