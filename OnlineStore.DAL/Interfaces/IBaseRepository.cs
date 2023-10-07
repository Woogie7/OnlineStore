using OnlineStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
