using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Response;
using OnlineStore.Domain.ViewModels.Product;

namespace OnlineStore.Service.Interfaces
{
	public interface IProductService
	{
		BaseResponse<Dictionary<int, string>> GetTypes();

		Task<IBaseResponse<List<Product>>> GetProducts();

		Task<IBaseResponse<ProductViewModel>> GetProduct(long id);

		Task<IBaseResponse<Product>> Create(ProductViewModel product);

		Task<IBaseResponse<bool>> DeleteProduct(long id);

		Task<IBaseResponse<Product>> Edit(long id, ProductViewModel model);
		Task<IBaseResponse<List<Product>>> GetProduct(string term);
	}
}
