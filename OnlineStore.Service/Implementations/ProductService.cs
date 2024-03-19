using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Response;
using OnlineStore.Service.Interfaces;
using OnlineStore.DAL.Interfaces;
using OnlineStore.Domain.ViewModels.Product;
using OnlineStore.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Repositories;

namespace OnlineStore.Service.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IBaseRepository<Product> _repository;
		private readonly IBaseRepository<TypeProduct> _typeProductRep;

		public ProductService(IBaseRepository<Product> productRepository, IBaseRepository<TypeProduct> TypeProductRep)
		{
			_repository = productRepository;
			_typeProductRep = TypeProductRep;
		}

		public async Task<IBaseResponse<Product>> Create(ProductViewModel product)
        {

            var typeProduct = await _typeProductRep.GetById(product.TypeProductId);

            if (typeProduct == null)
            {
                return new BaseResponse<Product>()
                {
                    Description = "Выбранный тип продукта не найден",
                    Status = StatusCode.InternalErrorServer
                };
            }

            try
			{
				var productNew = new Product()
				{
					Name = product.Name,
					Description = product.Description,
					Price = product.Price,
					TypeProductId = product.TypeProductId,
					TypeProduct = typeProduct,
					Image = "vobler_smith_camion.jpeg"
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

		public async Task<IBaseResponse<bool>> DeleteProduct(int id)
		{
			try
			{
				var car = await _repository.GetById(id);
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
			catch (Exception ex)
			{
				return new BaseResponse<bool>()
				{
					Description = $"[Create] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}

		public async Task<IBaseResponse<Product>> Edit(int id, ProductViewModel model)
		{
			try
			{
                var productEdit = await _repository.GetById(id);
                if (productEdit == null)
				{
					return new BaseResponse<Product>()
					{
						Description = "Продукт не неайден",
						Status = StatusCode.ProductNotFound
					};
				}

                var typeProduct = await _typeProductRep.GetById(model.TypeProductId);

                if (typeProduct == null)
                {
                    return new BaseResponse<Product>()
                    {
                        Description = "Выбранный тип продукта не найден",
                        Status = StatusCode.InternalErrorServer
                    };
                }

                productEdit.Description = model.Description;
				productEdit.Price = model.Price;
				productEdit.Name = model.Name;
				productEdit.TypeProductId = model.TypeProductId;
				productEdit.TypeProduct = typeProduct;


                await _repository.Update(productEdit);


				return new BaseResponse<Product>()
				{
					Data = productEdit,
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

		public async Task<IBaseResponse<ProductViewModel>> GetProduct(int id)
		{
			try
			{
				var product = await _repository.GetById(id);
				if (product == null)
				{
					return new BaseResponse<ProductViewModel>()
					{
						Description = "Продукт не найден",
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
					Status = StatusCode.InternalErrorServer
				};
			}
		}

		public async Task<IBaseResponse<IEnumerable<Product>>> GetProduct(string term)
		{
			try
			{
				var products = await _repository.GetAll();

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
					return new BaseResponse<IEnumerable<Product>>()
					{
						Description = "Найдено 0 элементов",
						Status = StatusCode.OK
					};
				}

				return new BaseResponse<IEnumerable<Product>>()
				{
					Data = products,
					Status = StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<IEnumerable<Product>>()
				{
					Description = $"[GetProductsAsync] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}


		public async Task<IBaseResponse<IEnumerable<Product>>> GetProducts()
		{
			try
			{
				var products = await _repository.GetAll();

				if (!products.Any())
				{
					return new BaseResponse<IEnumerable<Product>>()
					{
						Description = "Найдено 0 элементов",
						Status = StatusCode.OK
					};
				}

				return new BaseResponse<IEnumerable<Product>>()
				{
					Data = products,
					Status = StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<IEnumerable<Product>>()
				{
					Description = $"[GetProductsAsync] : {ex.Message}",
					Status = StatusCode.InternalErrorServer
				};
			}
		}

		public async Task<IEnumerable<TypeProduct>> GetTypes()
		{
			try
			{
				var types = await _typeProductRep.GetAll();
				return types;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
