using OnlineStore.Domain.Entity;

namespace OnlineStore.DAL.Interfaces
{
	public interface IBaseRepository<T> where T : class, IEntity
	{
		Task Create(T entity);
        Task<IEnumerable<T>> GetAll();
		Task<T> GetById(int id);
		Task<T> GetByName(string name);
        Task Delete(T entity);
		Task<T> Update(T entity);
	}
}
