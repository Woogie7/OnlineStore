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

		public async Task<IBaseResponse<Product>> Create(ProductViewModel product)
		{
			try
			{
				var productNew = new Product()
				{
					Name = product.Name,
					Description = product.Description,
					Price = product.Price,
					TypeProduct = product.TypeProduct,
				};
				await _repository.Create(productNew);

				return new BaseResponse<Product>()
				{
					Status = StatusCode.OK,
					Data = productNew
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
				var car = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
				if (car == null)
				{
					return new BaseResponse<bool>()
					{
						Description = "User not found",
						Status = StatusCode.UserNotFound,
						Data = false
					};
				}

				await _repository.Delete(car);

				return new BaseResponse<bool>()
				{
					Data = true,
					Status = StatusCode.OK
				};
			}
			catch(Exception ex)
			{
				return new BaseResponse<bool>()
				{
					Description = $"[Create] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}

		public async Task<IBaseResponse<Product>> Edit(long id, ProductViewModel model)
		{
			try
			{
				var productEdit = await _repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
				if (productEdit == null)
				{
					return new BaseResponse<Product>()
					{
						Description = "Car not found",
						Status = StatusCode.ProductNotFound
					};
				}

				productEdit.Description = model.Description;
				productEdit.Price = model.Price;
				productEdit.Name = model.Name;
				productEdit.TypeProduct = model.TypeProduct;

				await _repository.Update(productEdit);


				return new BaseResponse<Product>()
				{
					Data = productEdit,
					Status = StatusCode.OK,
				};
				// TypeCar
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
					Name = product.Name,
					Description = product.Description,
					Price = product.Price,
					TypeProduct = product.TypeProduct,
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
					Status= StatusCode.InternalErrorServer
				};
			}
		}

		public async Task<IBaseResponse<List<Product>>> GetProduct(string term)
		{
			try
			{
				var products = await _repository.GetAll()
					.Where(x => x.Name.Contains(term))
					.ToListAsync();

				var productViewModels = products.Select(x => new ProductViewModel()
				{
					Id = x.Id,
					Name = x.Name,
					Description = x.Description,
					Price = x.Price,
					TypeProduct = x.TypeProduct,
					Image = x.Image
				}).ToList();

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
					Description = $"[GetProductsAsync] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}


		public async Task<IBaseResponse<List<Product>>> GetProducts()
		{
			try
			{
				var products = await _repository.GetAll().ToListAsync();

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
					Description = $"[GetProductsAsync] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
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
					Status= StatusCode.InternalErrorServer
				};
			}
		}
	}
}
