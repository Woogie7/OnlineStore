using OnlineStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Interfaces
{
	public interface IProductRepository : IBaseRepository<Product>
	{
		Task<Product> GetByNameAsync(string name);

	}
}
