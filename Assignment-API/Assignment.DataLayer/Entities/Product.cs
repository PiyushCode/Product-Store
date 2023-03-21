namespace Assignment.DataLayer.Entities
{
	public class Product : Entity<Guid>
	{
		public string Name { get; set; }

		public string Image { get; set; }

		public double Price { get; set; }

		public double Rating { get; set; }

		public virtual Category Category { get; set; }

		public Guid CategoryId { get; set; }
	}
}
