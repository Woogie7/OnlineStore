using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace OnlineStore.Controllers
{
	[ApiController]
	[Route("api/bot")]
	public class TelegramController : ControllerBase
	{
		

		[HttpPost]
		private async Task<ActionResult> Post([FromBody] Update update)
		{
			TelegramBotClient Bot = new TelegramBotClient("6986388747:AAH0pqDcBUUrmbQSsDzMLVQpZriwe54ojk8");
			
			if(update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
			{
				await Bot.SendTextMessageAsync(update.Message.From.Id, "answer");
			}

			return Ok();
		}
	}
}
