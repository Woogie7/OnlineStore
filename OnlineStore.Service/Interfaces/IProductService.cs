using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Response;
using OnlineStore.Domain.ViewModels.Product;

namespace OnlineStore.Service.Interfaces
{
	public interface IProductService
	{
		Task<IBaseResponse<IEnumerable<Product>>> GetProducts();
		
		Task<IBaseResponse<Product>> GetProduct(int id);
		
		Task<IBaseResponse<Product>> GetProductByName(string name);
		
		Task<IBaseResponse<bool>> DeleteProduct(int id);

		Task<IBaseResponse<ProductViewModel>> CreateProduct(ProductViewModel productViewModel);

		Task<IBaseResponse<Product>> Edit(int id, ProductViewModel model);
	}
}
