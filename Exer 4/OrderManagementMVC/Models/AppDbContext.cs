using Microsoft.EntityFrameworkCore;

namespace OrderManagementMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Đổi tên bảng Order thành [Order] để tránh conflict với keyword SQL
            modelBuilder.Entity<Order>().ToTable("Order");
        }
    }
}