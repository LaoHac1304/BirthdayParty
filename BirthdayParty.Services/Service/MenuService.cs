using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.Discounts;
using BirthdayParty.Domain.Payload.Request.Menus;
using BirthdayParty.Domain.Payload.Response.Discounts;
using BirthdayParty.Domain.Payload.Response.Menus;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.Services.Service
{
    public class MenuService : BaseService<IMenuService>, IMenuService
    {
        public MenuService(IUnitOfWork unitOfWork, ILogger<IMenuService> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
        {
        }

        public async Task<GetMenuResponse> CreateMenu(CreateMenuRequest createMenuRequest)
        {
            Menu menu = _mapper.Map<Menu>(createMenuRequest);
            menu.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.GetRepository<Menu>().InsertAsync(menu);
            await _unitOfWork.CommitAsync();

            GetMenuResponse response = _mapper.Map<GetMenuResponse>(menu);
            return response;
        }

        public async Task<GetMenuResponse> GetMenuById(string id)
        {
            if (id == string.Empty) throw new BadHttpRequestException("Menu Id is null or not exist");

            GetMenuResponse response = await _unitOfWork.GetRepository<Menu>().SingleOrDefaultAsync(
                selector: x => new GetMenuResponse(x.Id, x.Name, x.Description, x.Price, x.CreatedAt, x.UpdatedAt, x.IsDeleted),
                predicate: x => x.Id.Equals(id));

            return response;
        }

        public async Task<IPaginate<GetMenuResponse>> GetMenus(int page, int size)
        {
            IPaginate<GetMenuResponse> response
                = await _unitOfWork.GetRepository<Menu>()
                .GetPagingListAsync(
                    selector: x => new GetMenuResponse(x.Id, x.Name, x.Description, x.Price, x.CreatedAt, x.UpdatedAt, x.IsDeleted),
                    page: page,
                    size: size,
                    orderBy: x => x.OrderBy(x => x.CreatedAt));

            return response;
        }

        public async Task<bool> UpdateMenuById(string id)
        {
            if (id == string.Empty) throw new BadHttpRequestException("Menu Id is null or not exist");

            Menu menu = await _unitOfWork.GetRepository<Menu>()
                .SingleOrDefaultAsync(
                predicate: x => x.Id.Equals(id));

            if (menu == null) throw new BadHttpRequestException("Menu was not found");

            _unitOfWork.GetRepository<Menu>().UpdateAsync(menu);
            menu.IsDeleted = true;
            menu.UpdatedAt = DateTime.UtcNow;

            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            return isSuccessful;
        }
    }
}
