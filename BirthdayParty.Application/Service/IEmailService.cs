using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Application.Service
{
    public interface IEmailService
    {
        Task SendEmailAsync(string orderDetailId);
    }
}
