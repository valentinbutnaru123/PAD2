using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        public ApiDbContext() { }    
       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.Entity<Customer>().HasKey(pt => pt.CustomerID);
       }
    }
    
}
