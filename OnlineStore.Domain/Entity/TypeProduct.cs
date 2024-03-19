using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entity
{
    public class TypeProduct : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
