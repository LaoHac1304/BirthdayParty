using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.RoomOnDutys;
using BirthdayParty.Domain.Payload.Request.Posts;
using BirthdayParty.Domain.Payload.Response.HostParties;
using BirthdayParty.Domain.Payload.Response.RoomOnDutys;
using BirthdayParty.Domain.Payload.Response.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Asn1.Ocsp;
using BirthdayParty.Domain.Payload.Response.Accounts;
using Microsoft.AspNetCore.Components.Forms;

namespace BirthdayParty.Services.Service;

public class RoomOnDutyService : BaseService<RoomOnDutyService>, IRoomOnDutyService
{
    private readonly IPostService _postService;

    public RoomOnDutyService(IUnitOfWork unitOfWork, ILogger<RoomOnDutyService> logger, IMapper mapper,
        IPostService postService,
        IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
    {
        _postService = postService;
    }

    public async Task<IPaginate<GetRoomOnDutysResponse>> GetRoomOnDutys(GetMenuRequest request)
    {
        try
        {
            var result = 
                await _unitOfWork.GetRepository<RoomOnDuty>().GetPagingListAsync< GetRoomOnDutysResponse > (
                selector: x => new GetRoomOnDutysResponse(x.Id, x.PartyPackageId, x.StartDate, x.EndDate, x.Status, x.CreatedAt, x.UpdateAt),
                predicate: x => x.PartyPackageId == request.PartyPackageId,
                orderBy: x => x.OrderBy(partyPackage => partyPackage.CreatedAt),
                page: request.Page,
                size: request.Size);

            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<GetSingleRoomOnDutyResponse> GetRoomOnDutyById(string id)
    {
        if (id == string.Empty) throw new BadHttpRequestException("RoomOnDuty Id is null or not exist");
        try
        {
            GetSingleRoomOnDutyResponse roomOnDutyResponse = await _unitOfWork.GetRepository<RoomOnDuty>().SingleOrDefaultAsync(
               selector: x => new GetSingleRoomOnDutyResponse(x.Id, x.PartyPackageId, x.StartDate, x.EndDate, x.Status, x.PartyPackage, x.CreatedAt, x.UpdateAt),
               predicate: x => x.Id.Equals(id));

            return roomOnDutyResponse;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<string> CreateRoomOnDuty(CreateRoomOnDutyRequest request)
    {
        try
        {
            var toBeAdded = new RoomOnDuty()
            {
                Id = Guid.NewGuid().ToString(),
                PartyPackageId = request.PartyPackageId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Status = "Processing"
            };

            await _unitOfWork.GetRepository<RoomOnDuty>().InsertAsync(toBeAdded);
            await _unitOfWork.CommitAsync();

            var message = "Created Successfully";

            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public async Task<string> UpdateRoomOnDuty(string id, UpdateRoomOnDutyRequest request)
    {
        try
        {
            var roomOnDuty = await _unitOfWork.GetRepository<RoomOnDuty>().SingleOrDefaultAsync(predicate: x => x.Id == request.Id);
            if (roomOnDuty == null) throw new BadHttpRequestException("RoomOnDuty was not found");

            var toBeUpdated = _mapper.Map(request, roomOnDuty);
            _unitOfWork.GetRepository<RoomOnDuty>().UpdateAsync(toBeUpdated);
            await _unitOfWork.CommitAsync();

            var message = "Updated Successfully";
            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public async Task<string> DeleteRoomOnDuty(string id)
    {
        try
        {
            var toBeDeleted = await _unitOfWork.GetRepository<RoomOnDuty>()
                .SingleOrDefaultAsync(predicate: x => x.Id == id);

            if (toBeDeleted == null) return "Not found";

            _unitOfWork.GetRepository<RoomOnDuty>().DeleteAsync(toBeDeleted);
            await _unitOfWork.CommitAsync();

            var message = "Deleted Successfully";
            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}