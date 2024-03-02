using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Response.OrderDetails;

namespace BirthdayParty.Application.Service
{
    public interface IPaymentDetailsService
    {
        Task<IPaginate<GetPaymentDetailResponse>> GetPaymentDetails(int page, int size);

        Task<GetPaymentDetailResponse> GetPaymentDetailById(string id);

        Task<bool> UpdatedPaymentDetailById(string id);
        Task<GetPaymentDetailResponse> CreatePaymentDetail(CreatePaymentDetailsRequest createPaymentDetailsRequest);
    }
}