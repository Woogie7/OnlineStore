using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Enum
{
	public enum TypeProduct
	{
		[Display(Name = "Охота")]
		Hunt = 0,
		[Display(Name ="Рыбалка")]
		Fishing = 1
	}
}
