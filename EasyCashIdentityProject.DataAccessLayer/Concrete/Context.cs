using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EasyCashIdentityProject.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=YAGMUR;database=EasyCashDb;integrated security=true;TrustServerCertificate=true");
        }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<AccountProcess> AccountProcesses { get; set; }

    }
}
