using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Discounts;
using BirthdayParty.Domain.Payload.Request.Menus;
using BirthdayParty.Domain.Payload.Response.Discounts;
using BirthdayParty.Domain.Payload.Response.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Application.Service.Common
{
    public interface IMenuService
    {
        Task<IPaginate<GetMenuResponse>> GetMenus(int page, int size);

        Task<GetMenuResponse> GetMenuById(string id);

        Task<bool> UpdateMenuById(string id);
        Task<GetMenuResponse> CreateMenu(CreateMenuRequest createMenuRequest);
        Task<IPaginate<GetMenuResponse>> GetMenusByPackageId(string id, int page, int size);
    }
}
