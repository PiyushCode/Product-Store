using Assignment.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.DataLayer.Mappings
{
	public class CategoryMapping : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Categories");
			builder.HasKey(x => x.Id);
			builder.HasData(
				new Category() { Id = Guid.Parse("42b2abcb-90d2-4f85-9ceb-75569c814f7d"), Name = "Category1", CreatedBy = "Admin", CreatedOn = DateTime.UtcNow, ModifiedOn = DateTime.UtcNow, ModifiedBy = "Admin" },
				new Category() { Id = Guid.Parse("ed9e9c95-35e6-444d-a5de-9424c98cac22"), Name = "Category2", CreatedBy = "Admin", CreatedOn = DateTime.UtcNow, ModifiedOn = DateTime.UtcNow, ModifiedBy = "Admin" },
				new Category() { Id = Guid.Parse("81dac9c0-4333-4d19-937d-cc2f8df85cbd"), Name = "Category3", CreatedBy = "Admin", CreatedOn = DateTime.UtcNow, ModifiedOn = DateTime.UtcNow, ModifiedBy = "Admin" },
				new Category() { Id = Guid.Parse("3e8e54d4-556a-4ab6-a055-09a1db9cd2c9"), Name = "Category4", CreatedBy = "Admin", CreatedOn = DateTime.UtcNow, ModifiedOn = DateTime.UtcNow, ModifiedBy = "Admin" }
				);
		}
	}
}
