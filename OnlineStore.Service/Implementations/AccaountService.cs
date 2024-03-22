using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineStore.DAL.Interfaces;
using OnlineStore.Domain.Entity;
using OnlineStore.Domain.Enum;
using OnlineStore.Domain.Hash;
using OnlineStore.Domain.Response;
using OnlineStore.Domain.ViewModels.Accaount;
using OnlineStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineStore.Service.Implementations
{
	public class AccountService : IAccountService
	{
		private readonly IBaseRepository<User> _userRepository;

		public AccountService(IBaseRepository<User> userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
		{
			try
			{
				var user = await _userRepository.GetByName(model.Name);

				if (user != null)
				{
					return new BaseResponse<ClaimsIdentity>()
					{
						Description = "Пользователь с таким логином или почтой уже существует",
					};
				}

				user = new User()
				{
					Name = model.Name,
					Role = Role.User,
					Password = HashPasswordUsers.HashPassowrd(model.Password),
				};

				await _userRepository.Create(user);
				var result = Authenticate(user);

				return new BaseResponse<ClaimsIdentity>()
				{
					Data = result,
					Description = "Объект добавился",
					Status = StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<ClaimsIdentity>()
				{
					Description = ex.Message,
					Status = StatusCode.InternalErrorServer
				};
			}
		}

		public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
		{
			try
			{
				var user = await _userRepository.GetByName(model.Name);

                if (user == null)
				{
					return new BaseResponse<ClaimsIdentity>()
					{
						Description = "Пользователь не найден"
					};
				}

				if (user.Password != HashPasswordUsers.HashPassowrd(model.Password))
				{
					return new BaseResponse<ClaimsIdentity>()
					{
						Description = "Неверный пароль или логин"
					};
				}
				var result = Authenticate(user);

				return new BaseResponse<ClaimsIdentity>()
				{
					Data = result,
					Status= StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<ClaimsIdentity>()
				{
					Description = ex.Message,
					Status = StatusCode.InternalErrorServer
				};
			}
		}

		private ClaimsIdentity Authenticate(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
			};
			return new ClaimsIdentity(claims, "ApplicationCookie",
				ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
		}
	}
}
