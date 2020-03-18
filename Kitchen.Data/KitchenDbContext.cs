using Kitchen.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Data
{
	public class KitchenDbContext : DbContext
	{
		public DbSet<Dish> Dishes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb);Initial Catalog=KitchenDb;");
		}
	}
}
