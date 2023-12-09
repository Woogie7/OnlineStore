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
		public string Name { get; set; }

		[Display(Name = "Електроная почта")]
		[Required(ErrorMessage = "Требуется указать адрес электронной почты")]
		[EmailAddress(ErrorMessage = "Неверный адрес электронной почты")]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Неверный адрес электронной почты")]
		public string Email { get; set; }

		[Required(ErrorMessage = "КОД ПОТВЕРЖДЕНИЯ")]
		public string ConfirmCode { get; set; }

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
