using Assignment.DataLayer.Entities;
using Assignment.DataLayer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DataLayer.Repositories.Implementations
{
	public class ProductRepository : BaseRepository<Product, Guid>,  IProductRepository
	{
		private readonly ProductDBContext dbContext;

        public ProductRepository(ProductDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

		public async Task<IEnumerable<Product>> GetAllProductAsync()
		{			 
			return await dbContext.Set<Product>().Include(c => c.Category).ToListAsync();
		}
	}
}
