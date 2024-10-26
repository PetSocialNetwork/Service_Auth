using Service_Auth.Contracts.Base;
using Service_Auth.Entities;

namespace Service_Auth.Repositories.Interfaces
{
    public interface IAccountRepository : IRepositoryEF<Account>
    {
        Task<Account?> FindAccountByEmail(string email, CancellationToken cancellationToken);
        Task<Account?> FindAccountById(Guid id, CancellationToken cancellationToken);
    }
}
