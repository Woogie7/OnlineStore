using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Response;
using OnlineStore.Domain.ViewModels.Product;

namespace OnlineStore.Service.Interfaces
{
	public interface IProductService
	{
		Task<IEnumerable<TypeProduct>> GetTypes();

		Task<IBaseResponse<IEnumerable<Product>>> GetProducts();

		Task<IBaseResponse<ProductViewModel>> GetProduct(int id);

		Task<IBaseResponse<Product>> Create(ProductViewModel product);

		Task<IBaseResponse<bool>> DeleteProduct(int id);

		Task<IBaseResponse<Product>> Edit(int id, ProductViewModel model);
		
		Task<IBaseResponse<IEnumerable<Product>>> GetProduct(string term);
	}
}
