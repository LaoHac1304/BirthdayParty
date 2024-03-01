using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.HostParties;
using BirthdayParty.Domain.Payload.Response.HostParties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Application.Service.Common
{
    public interface IHostPartyService
    {
        Task<string> CreateHostParty(CreateHostPartyRequest createHostPartyRequest);
        Task<IPaginate<GetHostPartyResponse>> GetHostParties(int page, int size);
    }
}
