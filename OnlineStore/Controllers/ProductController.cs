using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.Entity;
using OnlineStore.Domain.ViewModels.Product;
using OnlineStore.Service.Interfaces;

namespace OnlineStore.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productsService;

		public ProductController(IProductService productService)
		{
			_productsService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> GetProducts()
		{
			var response = await _productsService.GetProducts();
			if (response.Status == Domain.Enum.StatusCode.OK)
			{
				return View(response.Data);
			}
			return RedirectToAction("Error");
		}

		[HttpGet]
		public async Task<IActionResult> GetProduct(int id)
		{
			var response = await _productsService.GetProduct(id);
			if (response.Status == Domain.Enum.StatusCode.OK)
			{
				return View(response.Data);
			}
			return RedirectToAction("Error");
		}

		[HttpGet]
		//public async Task<IActionResult> GetProductByName(string inputName)
		//{
		//	if (inputName == null)
		//	{
		//		return RedirectToAction("GetProducts");
		//	}
		//	else
		//	{
		//		var response = await _productsService.GetProduct(inputName);
		//		if (response.Status == Domain.Enum.StatusCode.OK)
		//		{
		//			return View("GetProducts", response.Data);
		//		}
		//		return RedirectToAction("Error");
		//	}
		//}



		#region Admin 

		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			var responce = await _productsService.DeleteProduct(id);
			if (responce.Status == Domain.Enum.StatusCode.OK)
			{
				return RedirectToAction("GetProducts");
			}
			return RedirectToAction("Error");
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Save(int id)
		{
			if (id == 0)
			{
				return View();
			}

			var response = await _productsService.GetProduct(id);
			if (response.Status == Domain.Enum.StatusCode.OK)
			{
				return View(response.Data);
			}

			return RedirectToAction("Error");
		}

		[HttpPost]
		public async Task<IActionResult> Save(ProductViewModel productViewModel)
		{
			if (ModelState.IsValid)
			{
				if (productViewModel.Id == 0)
				{
					await _productsService.Create(productViewModel);
				}
				else 
				{
					await _productsService.Edit(productViewModel.Id, productViewModel);
				}

			}
			return RedirectToAction("GetProducts");
		}

		#endregion
	}
}
