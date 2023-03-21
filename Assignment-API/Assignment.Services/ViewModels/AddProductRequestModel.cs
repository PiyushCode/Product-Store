using System.ComponentModel.DataAnnotations;

namespace Assignment.Services.ViewModels
{
	public class AddProductRequestModel
	{
		[Required]
		public string ProductName { get; set; }

		[Required]
		public Guid CategoryId { get; set; }

		[Required]
		public double Price { get; set; }
	}
}
