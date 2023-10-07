using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Response;

namespace OnlineStore.Service.Interfaces
{
	public interface IProductService
	{
		Task<IBaseResponse<IEnumerable<Product>>> GetProduct();
	}
}
