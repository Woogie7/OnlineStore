using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Response;
using OnlineStore.Domain.ViewModels.Product;

namespace OnlineStore.Service.Interfaces
{
	public interface IProductService
	{
		BaseResponse<Dictionary<int, string>> GetTypes();

		IBaseResponse<List<Product>> GetProducts();

		Task<IBaseResponse<ProductViewModel>> GetProduct(long id);

		Task<BaseResponse<Dictionary<int, string>>> GetProduct(string term);

		Task<IBaseResponse<Product>> Create(ProductViewModel product, byte[] imageData);

		Task<IBaseResponse<bool>> DeleteProduct(long id);

		Task<IBaseResponse<Product>> Edit(long id, ProductViewModel model);
	}
}
