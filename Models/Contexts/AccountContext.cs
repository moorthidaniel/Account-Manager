using Microsoft.EntityFrameworkCore;
using AccountManager.Models;
namespace AccountManager.Models.Contexts
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> opts) : base(opts)
        {

        }

        public DbSet<OnlineAccount> OnlineAccounts {get;set;}
    }
}