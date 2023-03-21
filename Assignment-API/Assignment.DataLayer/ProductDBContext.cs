using Assignment.DataLayer.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DataLayer
{
	public class ProductDBContext : DbContext
	{
		public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) { }

		/// <summary>
		/// On model creating
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new CategoryMapping());
			modelBuilder.ApplyConfiguration(new ProductMapping());

		}
	}
}
