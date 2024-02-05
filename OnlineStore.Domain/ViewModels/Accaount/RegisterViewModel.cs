﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.ViewModels.Accaount
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Укажите имя")]
		[MaxLength(20, ErrorMessage = "Имя должно иметь длину меньше 20 символов")]
		[MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]
		[RegularExpression("/^[a-zA-Z0-9]+$/", ErrorMessage = "Неверный логин")]
		public string Name { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Укажите пароль")]
		[MinLength(1, ErrorMessage = "Пароль должен иметь длину больше 6 символов")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Подтвердите пароль")]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		public string PasswordConfirm { get; set; }
	}
}
