using Assignment.DataLayer.Entities;
using Assignment.DataLayer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Assignment.DataLayer.Repositories.Implementations
{
	public class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : class, IEntity<TId>
	{
		private readonly ProductDBContext dbContext;
		private DbSet<T> entities;

        public BaseRepository(ProductDBContext dbContext)
        {
            this.dbContext = dbContext;
			this.entities = dbContext.Set<T>();
		}

        public Task DeleteAsync(T entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteByIdAsync(TId id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await entities.ToListAsync();
		}

		public Task<T> GetByIdAsync(TId id)
		{
			throw new NotImplementedException();
		}

		public async Task InsertAsync(T entity)
		{
			if(entity == null)
				throw new ArgumentNullException(nameof(entity));

			entities.Add(entity);
			await dbContext.SaveChangesAsync();
		}

		public Task UpdateAsync(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
