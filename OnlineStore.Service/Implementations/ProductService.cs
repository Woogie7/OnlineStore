using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Response;
using OnlineStore.Service.Interfaces;
using OnlineStore.DAL.Interfaces;
using OnlineStore.Domain.ViewModels.Product;
using OnlineStore.Domain.Enum;

namespace OnlineStore.Service.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repository;

		public ProductService(IProductRepository repository) 
		{
			_repository = repository;
		}
		public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
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
					Description = $"[GetProducts] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}
		public async Task<IBaseResponse<Product>> GetProduct(int id)
		{
			var baseResponse = new BaseResponse<Product>();
			try
			{
				var product = await _repository.Get(id);
                if (product == null)
                {
					baseResponse.Description = "Найдено 0 элементов";
					baseResponse.Status = Domain.Enum.StatusCode.UserNotFound;

					return baseResponse;
				}
				
				baseResponse.Data = product;
				return baseResponse;
            }
			catch (Exception ex)
			{
				return new BaseResponse<Product>()
				{
					Description = $"[GetProduct] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}

		}
		public async Task<IBaseResponse<Product>> GetProductByName(string name)
		{
			var baseResponse = new BaseResponse<Product>();
			try
			{
				var product = await _repository.GetByNameAsync(name);
				if (product == null)
				{
					baseResponse.Description = "Найдено 0 элементов";
					baseResponse.Status = Domain.Enum.StatusCode.UserNotFound;

					return baseResponse;
				}

				baseResponse.Data = product;
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Product>()
				{
					Description = $"[GetByNameAsync] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}
		public async Task<IBaseResponse<bool>> DeleteProduct(int id)
		{
			var baseResponse = new BaseResponse<bool>()
			{
				Data = true
			};
			try
			{
				var product = await _repository.Get(id);
				if (product == null)
				{
					baseResponse.Description = "User not found";
					baseResponse.Status = StatusCode.UserNotFound;
					baseResponse.Data = false;

					return baseResponse;
				}

				await _repository.Delete(product);

				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>()
				{
					Description = $"[DeleteProduct] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}
		public async Task<IBaseResponse<ProductViewModel>> CreateProduct(ProductViewModel productViewModel)
		{
			var baseResponse = new BaseResponse<ProductViewModel>();
			try
			{
				var product = new Product()
				{
					Name = productViewModel.Name,
					Description= productViewModel.Description,
					Price = productViewModel.Price,
					TypeProduct = (TypeProduct)Convert.ToInt32(productViewModel.TypeProduct)
				};

				await _repository.Create(product);
			}
			catch (Exception ex)
			{
				return new BaseResponse<ProductViewModel>()
				{
					Description = $"[CreateProduct] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
			return baseResponse;
		}

		public async Task<IBaseResponse<Product>> Edit(int id, ProductViewModel model)
		{
			var baseResponse = new BaseResponse<Product>();
			try
			{
				var product = await _repository.Get(id);
				if(product== null)
				{
					baseResponse.Status = StatusCode.ProductNotFound;
					baseResponse.Description = "Product not found";
					return baseResponse;
				}

				product.Description = model.Description;
				product.Name = model.Name;
				product.Price = model.Price;
				//product.TypeProduct = 

				await _repository.Update(product);


				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Product>()
				{
					Description = $"[Edit] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}
	}
}
