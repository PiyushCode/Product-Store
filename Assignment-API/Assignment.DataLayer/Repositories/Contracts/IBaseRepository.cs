using Assignment.DataLayer.Entities;

namespace Assignment.DataLayer.Repositories.Contracts
{
	public interface IBaseRepository<T, TId> where T : class, IEntity<TId>
	{
		Task<IEnumerable<T>> GetAllAsync();

		Task<T> GetByIdAsync(TId id);

		Task InsertAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteByIdAsync(TId id);
	}
}
