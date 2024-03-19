using Microsoft.AspNetCore.Http;
using OnlineStore.Domain.Entity;
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
		public TypeProduct TypeProduct { get; set; }

        [Display(Name = "Тип продукта")]
        [Required(ErrorMessage = "Выберите тип")]
        public int TypeProductId { get; set; } 

        [Display(Name = "Фотография")]
		[Required(ErrorMessage = "Выберите фото")]
		public string Image { get; set; }
	}
}

