using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Enum
{
	public enum StatusCode
	{
		UserNotFound = 0,
		ProductNotFound = 1,
		OK = 200,
		InternalErrorServer = 500
	}
}
