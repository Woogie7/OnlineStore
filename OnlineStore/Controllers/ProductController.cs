

using Microsoft.AspNetCore.Mvc;
using OnlineStore.DAL.Interfaces;

namespace OnlineStore.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository _repository;

		public ProductController(IProductRepository productRepository)
		{
			_repository = productRepository;
		}
		[HttpGet]
		public async Task<IActionResult> GetProducts()
		{
			var response = await _repository.Select();
			return View(response);
		}
	}
}
