using Assignment.DataLayer.Entities;
using Assignment.Services.ViewModels;

namespace Assignment.Services.Services.Contracts
{
	public interface IProductService
	{
		Task<List<ProductResponseModel>> GetAllProductAsync();

		Task AddProduct(AddProductRequestModel addProductRequest);
	}
}
