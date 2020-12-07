using Microsoft.EntityFrameworkCore;
using eLoan.Models;

namespace eLoan.Data
{
    public class eLoanContext : DbContext
    {
        public eLoanContext(DbContextOptions<eLoanContext> options) : base(options)
        {
        }

        public DbSet<Address> address { get; set; }
        //public DbSet<Application> applications { get; set; }
        //public DbSet<Bank> banks { get; set; }
        //public DbSet<Customer> customers { get; set; }
        //public DbSet<Loan> loans { get; set; }
        //public DbSet<Login> logins { get; set; }
        public DbSet<Profile> profiles { get; set; }

        //Database testing
        //public DbSet<TestTable> testTables { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Address>().ToTable("Address");
            //    modelBuilder.Entity<Application>().ToTable("Application");
            //    modelBuilder.Entity<Bank>().ToTable("Bank");
            //    modelBuilder.Entity<Customer>().ToTable("Customer");
            //    modelBuilder.Entity<Loan>().ToTable("Loan");
            //    modelBuilder.Entity<Login>().ToTable("Login");
            modelBuilder.Entity<Profile>().ToTable("Profile");

            //    //Database testing
            //    modelBuilder.Entity<TestTable>().ToTable("TestTable");
        }

    }
}
