using Microsoft.EntityFrameworkCore;
using Service_Auth.Configurations;
using Service_Auth.Contracts.Base;
using Service_Auth.Entities;
using Service_Auth.Repositories.Interfaces;

namespace Service_Auth.Repositories
{
    public class AccountRepository : EFRepository<Account>, IAccountRepository
    {
        public AccountRepository(AccountDbContext appDbContext) : base(appDbContext) { }
        public async Task<Account?> FindAccountByEmail(string email, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(email);

            return await Entities.SingleOrDefaultAsync(it => it.Email.Value == email, cancellationToken);
        }

        public async Task<Account?> FindAccountById(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.SingleOrDefaultAsync(it => it.Id == id, cancellationToken);
        }
    }
}
