using AutoMapper;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Payload.Request.RoomOnDutys;

namespace BirthdayParty.Services.Mappers.RoomOnDutys
{
    public class RoomOnDutyMapper : Profile
    {
        public RoomOnDutyMapper()
        {
            CreateMap<CreateRoomOnDutyRequest, RoomOnDuty>();
            CreateMap<UpdateRoomOnDutyRequest, RoomOnDuty>().IgnoreNull();
        }
    }

}
