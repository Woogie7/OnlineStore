using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.ViewModels.Accaount
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Введите имя")]
		[MaxLength(20, ErrorMessage = "Имя должно иметь длину меньше 20 символов")]
		[MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Введите пароль")]
		[DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }

		//[Display(Name = "Електроная почта")]
		//[Required(ErrorMessage = "Требуется указать адрес электронной почты")]
		//[EmailAddress(ErrorMessage = "Неверный адрес электронной почты")]
		//[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Неверный адрес электронной почты")]
		//public string Email { get; set; }
	}
}
