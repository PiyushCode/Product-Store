namespace Assignment.DataLayer.Entities
{
	public class Category : Entity<Guid>
	{
		public string? Name { get; set; }

		public ICollection<Product>? Products { get; set; }
	}
}
