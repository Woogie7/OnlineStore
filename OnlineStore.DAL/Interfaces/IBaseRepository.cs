using OnlineStore.Domain.Entity;

namespace OnlineStore.DAL.Interfaces
{
	public interface IBaseRepository<T>
	{
		Task<bool> CreateAsync(T entity);

		Task<Product> Get(int id);

		Task<List<Product>> Select();

		Task<bool> Delete(T entity);
	}
}
