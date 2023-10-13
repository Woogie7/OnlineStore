using Microsoft.AspNetCore.Http;
using OnlineStore.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.ViewModels.Product
{
	public class ProductViewModel
	{
		public int Id { get; set; }

		[Display(Name = "Название")]
		[Required(ErrorMessage = "Введите имя")]
		[MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
		public string Name { get; set; }

		[Display(Name = "Описание")]
		[MinLength(50, ErrorMessage = "Минимальная длина должна быть больше 50 символов")]
		public string Description { get; set; }

		[Display(Name = "Стоимость")]
		[Required(ErrorMessage = "Укажите стоимость")]
		public decimal Price { get; set; }

		[Display(Name = "Тип продукта")]
		[Required(ErrorMessage = "Выберите тип")]
		public string TypeProduct { get; set; }

		public IFormFile Avatar { get; set; }

		public byte[]? Image { get; set; }
	}
}

