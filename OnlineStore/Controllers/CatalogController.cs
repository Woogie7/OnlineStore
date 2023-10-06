using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
