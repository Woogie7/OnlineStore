using Microsoft.AspNetCore.Http;
using OnlineStore.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entity
{
	public class Product : IEntity
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
        public int TypeProductId { get; set; }
        public TypeProduct TypeProduct { get; set; }
		public string Image { get; set; }
	}
}
