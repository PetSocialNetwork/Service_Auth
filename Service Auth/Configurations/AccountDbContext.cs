using Microsoft.EntityFrameworkCore;
using Service_Auth.Entities;

namespace Service_Auth.Configurations
{
    public class AccountDbContext : DbContext
    {
        DbSet<Account> Account => Set<Account>();
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .OwnsOne(a => a.Email);
        }
    }
}
