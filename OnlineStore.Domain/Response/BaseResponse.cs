using OnlineStore.Domain.Enum;

namespace OnlineStore.Domain.Response
{
	public class BaseResponse<T> : IBaseResponse<T>
	{
		public string Description { get; set; }

		public StatusCode Status { get; set; }

		public T Data { get; set; }
	}

	public interface IBaseResponse<T>
	{
		T Data { get; set; }
	}
}
