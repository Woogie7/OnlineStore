using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers
{
    public class CatalogController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
