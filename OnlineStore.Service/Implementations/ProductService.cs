using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Response;
using OnlineStore.Service.Interfaces;
using OnlineStore.DAL.Interfaces;
using OnlineStore.Domain.ViewModels.Product;
using OnlineStore.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Service.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IBaseRepository<Product> _repository;

		public ProductService(IBaseRepository<Product> productRepository)
		{
			_repository = productRepository;
		}

		public BaseResponse<Dictionary<int, string>> GetTypes()
		{
			try
			{
				var types = ((TypeProduct[])Enum.GetValues(typeof(TypeProduct)))
					.ToDictionary(k => (int)k, t => t.GetDisplayName());

				return new BaseResponse<Dictionary<int, string>>()
				{
					Data = types,
					Status = StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<Dictionary<int, string>>()
				{
					Description = ex.Message,
					Status = StatusCode.InternalErrorServer
				};
			}
		}

		public async Task<IBaseResponse<ProductViewModel>> GetProduct(long id)
		{
			try
			{
				var product = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
				if (product == null)
				{
					return new BaseResponse<ProductViewModel>()
					{
						Description = "Пользователь не найден",
						Status = StatusCode.UserNotFound
					};
				}

				var data = new ProductViewModel()
				{
					Description = product.Description,
					Name = product.Name,
					Price = product.Price,
					TypeProduct = product.TypeProduct.GetDisplayName(),
					Image = product.Image
				};

				return new BaseResponse<ProductViewModel>()
				{
					Status = StatusCode.OK,
					Data = data
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<ProductViewModel>()
				{
					Description = $"[GetCar] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}

		public async Task<BaseResponse<Dictionary<int, string>>> GetProduct(string term)
		{
			var baseResponse = new BaseResponse<Dictionary<int, string>>();
			try
			{
				var products = await _repository.GetAll()
					.Select(x => new ProductViewModel()
					{
						Id = x.Id,
						Name = x.Name,
						Description = x.Description,
						Price = x.Price,
						TypeProduct = x.TypeProduct.GetDisplayName(),
						Image = x.Image
						
					})
					.Where(x => EF.Functions.Like(x.Name, $"%{term}%"))
					.ToDictionaryAsync(x => x.Id, t => t.Name);

				baseResponse.Data = products;
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Dictionary<int, string>>()
				{
					Description = ex.Message,
					Status = StatusCode.InternalErrorServer
				};
			}
		}

		public async Task<IBaseResponse<Product>> Create(ProductViewModel model)
		{
			try
			{
				var product = new Product()
				{
					Name = model.Name,
					Description = model.Description,
					TypeProduct = (TypeProduct)Convert.ToInt32(model.TypeProduct),
					Price = model.Price,
					Image = model.Image
				};
				await _repository.Create(product);

				return new BaseResponse<Product>()
				{
					Status = StatusCode.OK,
					Data = product
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<Product>()
				{
					Description = $"[Create] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}

		public async Task<IBaseResponse<bool>> DeleteProduct(long id)
		{
			try
			{
				var products = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
				if (products == null)
				{
					return new BaseResponse<bool>()
					{
						Description = "User not found",
						Status = StatusCode.UserNotFound,
						Data = false
					};
				}

				await _repository.Delete(products);

				return new BaseResponse<bool>()
				{
					Data = true,
					Status = StatusCode.OK
				};
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

		public async Task<IBaseResponse<Product>> Edit(long id, ProductViewModel model)
		{
			try
			{
				var product = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
				if (product == null)
				{
					return new BaseResponse<Product>()
					{
						Description = "Car not found",
						Status = StatusCode.InternalErrorServer
					};
				}

				product.Description = model.Description;
				product.Price = model.Price;
				product.Name = model.Name;

				await _repository.Update(product);


				return new BaseResponse<Product>()
				{
					Data = product,
					Status = StatusCode.OK,
				};
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

		public IBaseResponse<List<Product>> GetProducts()
		{
			try
			{
				var products = _repository.GetAll().ToList();
				if (!products.Any())
				{
					return new BaseResponse<List<Product>>()
					{
						Description = "Найдено 0 элементов",
						Status = StatusCode.OK
					};
				}

				return new BaseResponse<List<Product>>()
				{
					Data = products,
					Status = StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<List<Product>>()
				{
					Description = $"[GetProducts] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}
	}
}
