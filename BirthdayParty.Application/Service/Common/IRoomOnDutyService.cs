using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.RoomOnDutys;
using BirthdayParty.Domain.Payload.Response.RoomOnDutys;

namespace BirthdayParty.Application.Service.Common;

public interface IRoomOnDutyService
{
    Task<IPaginate<GetRoomOnDutysResponse>> GetRoomOnDutys(GetMenuRequest request);
    Task<GetSingleRoomOnDutyResponse> GetRoomOnDutyById(string id);
    Task<string> CreateRoomOnDuty(CreateRoomOnDutyRequest request);
    Task<string> UpdateRoomOnDuty(string id, UpdateRoomOnDutyRequest request);
    Task<string> DeleteRoomOnDuty(string id);
}