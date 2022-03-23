using Microsoft.EntityFrameworkCore;

namespace AddressBook.MVC.Models.DataModels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Employer> Employers { get; set; }
    }
}
