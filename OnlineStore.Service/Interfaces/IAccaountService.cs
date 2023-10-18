using OnlineStore.Domain.Response;
using OnlineStore.Domain.ViewModels.Accaount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Interfaces
{
	public interface IAccountService
	{
		Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

		Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

		//Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
	}
}
