using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDishes> OrdersDishes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDishes>()
                .HasKey(o => new { o.OrderId, o.DishId });
            builder.Entity<OrderDishes>()
                .HasOne(o => o.Dish)
                .WithMany(d => d.Orders)
                .HasForeignKey(o => o.DishId);
            builder.Entity<OrderDishes>()
                .HasOne(d => d.Order)
                .WithMany(o => o.Dishes)
                .HasForeignKey(d => d.OrderId);

            base.OnModelCreating(builder);
        }
    }
}
