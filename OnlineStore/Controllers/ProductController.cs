using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
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
			var response = await _productsService.GetProduct();
			return View();
		}
	}
}
