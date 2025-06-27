using Microsoft.EntityFrameworkCore;
using ContactBook.Api.Models;

namespace ContactBook.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Order>    Orders    => Set<Order>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            // Table and key mapping
            b.Entity<Customer>().ToTable("Customer").HasKey(c => c.Id);
            b.Entity<Order>().ToTable("Order").HasKey(o => o.Id);

            b.Entity<Order>().Property(o => o.CreatedAt).HasColumnName("CreatedAt");

            // One-to-many relationship
            b.Entity<Customer>()
                 .HasMany(c => c.Orders)
                 .WithOne()
                 .HasForeignKey(o => o.Id);
        }
    }
}
