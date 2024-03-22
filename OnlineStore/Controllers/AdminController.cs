using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineStore.Domain.Entity;
using OnlineStore.Domain.ViewModels.Product;
using OnlineStore.Domain.ViewModels.User;
using OnlineStore.Service.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> AdminProduct()
        {
            var response = await _productService.GetProducts();
            if (response.Status == Domain.Enum.StatusCode.OK)
            {
                var productsViewModel = response.Data.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    TypeProductId = p.TypeProductId,
                    TypeProduct = p.TypeProduct,
                    Image = p.Image,
                    ImageFile = null
                }).ToList();

                return View(productsViewModel);
            }
            
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            IEnumerable<TypeProduct> typeProducts = await _productService.GetTypes(); 

            IEnumerable<SelectListItem> typeProductsSelectList = typeProducts
            .Select(tp => new SelectListItem
            {
                Text = tp.Name,
                Value = tp.Id.ToString()
            });

            ViewBag.TypeProductId = typeProductsSelectList;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {

            var result = await _productService.Create(productViewModel);

            if (result.Status == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("AdminProduct");
            }
            else
            {
                return BadRequest(new { errorMessage = "Ошибка сохранения продукта." });
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id) 
        {
            var productResponse = await _productService.GetProduct(id);

            if (productResponse.Status == Domain.Enum.StatusCode.OK)
            {
                IEnumerable<TypeProduct> typeProducts = await _productService.GetTypes();

                IEnumerable<SelectListItem> typeProductsSelectList = typeProducts
                .Select(tp => new SelectListItem
                {
                    Text = tp.Name,
                    Value = tp.Id.ToString()
                });

                ViewBag.TypeProductId = typeProductsSelectList;

                return View(productResponse.Data);
            }

            return RedirectToAction("Index", "Home");
        }

		[HttpPost]
		public async Task<IActionResult> Edit(ProductViewModel productViewModel)
		{
			var result = await _productService.Edit(productViewModel.Id, productViewModel);

			if (result.Status == Domain.Enum.StatusCode.OK)
			{
				return RedirectToAction("AdminProduct");
			}
			else
			{
				return BadRequest(new { errorMessage = "Ошибка сохранения продукта." });
			}
		}
	}
}
