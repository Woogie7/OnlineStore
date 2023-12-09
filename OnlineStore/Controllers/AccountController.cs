using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OnlineStore.Domain.ViewModels.Accaount;
using OnlineStore.Service.Implementations;
using OnlineStore.Service.Interfaces;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;
		private readonly IEmailSenderService _emailSenderService;

		public AccountController(IAccountService accountService, IEmailSenderService emailSenderService)
		{
			_accountService = accountService;
			_emailSenderService = emailSenderService;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var response = await _accountService.Register(model);
				if (response.Status == Domain.Enum.StatusCode.OK)
				{
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(response.Data));
					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError("Name", response.Description);
			}
			return View(model);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var response = await _accountService.Login(model);
				if (response.Status == Domain.Enum.StatusCode.OK)
				{
					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(response.Data));
					return RedirectToAction("Index", "Home");
				}
				ModelState.AddModelError("Name", response.Description);
			}
			return View(model);
		}

		[HttpGet]
        public async Task<IActionResult> Loggout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

		[HttpPost]
		public IActionResult SendConfirmationCode([FromBody] string email)
		{
			string confirmationCode = GenerateConfirmationCode();
			_emailSenderService.SendEmailAsync(email, "Код подтверждения", confirmationCode);

			return Ok(); // Assuming success; you can modify this based on your needs
		}


		private string GenerateConfirmationCode()
		{
			Random random = new Random();
			int confirmationCode = random.Next(100000, 999999);
			return confirmationCode.ToString();
		}
	}
}
