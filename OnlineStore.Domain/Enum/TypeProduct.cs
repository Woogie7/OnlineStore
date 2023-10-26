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
		[Display(Name = "Удилища")]
		Rods = 0,
		[Display(Name ="Котушки")]
		Reels = 1,
		[Display(Name = "Приманки для рыбалки")]
		LuresForFishing = 2,
		[Display(Name = "Амуниция")]
		Ammunition = 3,
		[Display(Name = "Аксессуары охотничьи")]
		HuntingAccessories = 4,
		[Display(Name = "Приманки для охоты")]
		LuresForHunting = 5
	}
}
