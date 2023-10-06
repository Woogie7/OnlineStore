using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}
	}
}
