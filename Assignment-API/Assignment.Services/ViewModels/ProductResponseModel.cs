using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Services.ViewModels
{
	public class ProductResponseModel
	{
		public Guid Id { get; set; }

		public string ProductName { get; set; }

		public string Image { get; set; }

		public double Rating { get; set; }

		public string CategoryName { get; set; }

		public double Price { get; set; }
	}
}
