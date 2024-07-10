using System.Threading.Tasks;

namespace ChallengeSND.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        IRepository<T> GetRepository<T>() where T : class;
    }
}
