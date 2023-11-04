using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyCashIdentityProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=YAGMUR;database=EasyCashDb;integrated security=true;TrustServerCertificate=true");
        }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<AccountProcess> AccountProcesses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AccountProcess>()
                    .HasOne(x => x.SenderCustomer)
                    .WithMany(y => y.CustomerSender)
                    .HasForeignKey(z => z.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<AccountProcess>()
                    .HasOne(x => x.ReceiverCustomer)
                    .WithMany(y => y.CustomerReceiver)
                    .HasForeignKey(z => z.ReceiverId)
                    .OnDelete(DeleteBehavior.SetNull);


            base.OnModelCreating(builder);
        }
    }
}
