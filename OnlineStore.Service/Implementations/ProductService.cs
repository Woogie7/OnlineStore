using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Response;
using OnlineStore.Service.Interfaces;
using OnlineStore.DAL.Interfaces;

namespace OnlineStore.Service.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repository;

		public ProductService(IProductRepository repository) 
		{
			_repository = repository;
		}
		public async Task<IBaseResponse<IEnumerable<Product>>> GetProduct()
		{
			var baseResponse = new BaseResponse<IEnumerable<Product>>();
			try
			{
				var products = await _repository.Select();
				if(products.Count == 0) 
				{
					baseResponse.Description = "Найдено 0 элементов";
					baseResponse.Status = Domain.Enum.StatusCode.OK;

					return baseResponse;
				}

				baseResponse.Data = products;
				baseResponse.Status = Domain.Enum.StatusCode.OK;

				return baseResponse;
			}
			catch(Exception ex) 
			{
				return new BaseResponse<IEnumerable<Product>>()
				{
					Description = $"[GetProduct] : {ex.Message}"
				};
			}
		}
	}
}
