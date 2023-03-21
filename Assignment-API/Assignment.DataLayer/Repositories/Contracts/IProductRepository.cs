using Assignment.DataLayer.Entities;

namespace Assignment.DataLayer.Repositories.Contracts
{
	public interface IProductRepository : IBaseRepository<Product, Guid>
	{
		Task<IEnumerable<Product>> GetAllProductAsync();
	}
}
