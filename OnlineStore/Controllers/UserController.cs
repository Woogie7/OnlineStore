using Microsoft.AspNetCore.Mvc;
using OnlineStore.Domain.ViewModels.User;
using OnlineStore.Service.Interfaces;
using System.Linq;

namespace OnlineStore.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            if (response.Status == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteUser(long id)
        {
            var response = await _userService.DeleteUser(id);
            if (response.Status == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetUsers");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public JsonResult GetRoles()
        {
            var types = _userService.GetRoles();
            return Json(types.Data);
        }

    }
}
