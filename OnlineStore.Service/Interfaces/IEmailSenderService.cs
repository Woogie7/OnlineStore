using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Service.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(string email, string subjet, string massenge);
    }
}
