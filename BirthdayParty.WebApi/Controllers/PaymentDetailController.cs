using Microsoft.AspNetCore.Mvc;
using BirthdayParty.Application.Service;
using BirthdayParty.WebApi.Constants;
using BirthdayParty.Services.Service;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Request.Accounts;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthdayParty.WebApi.Controllers
{
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly IPaymentDetailsService paymentDetailsService;

        public PaymentDetailsController(IPaymentDetailsService paymentDetailsService)
        {
            this.paymentDetailsService = paymentDetailsService;
        }

        // GET: api/<OrderDetailsController>
        [HttpGet(ApiEndPointConstant.PaymentDetail.PaymentDetailsEndpoint)]
        public async Task<IActionResult> GetOrderDetails([FromQuery]int page, [FromQuery]int size)
        { 
            var orderDetail = await paymentDetailsService.GetPaymentDetails(page, size);
            return Ok(orderDetail);
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet(ApiEndPointConstant.PaymentDetail.PaymentDetailEndpoint)]
        public async Task<IActionResult> GetById(string id)
        {
            var orderDetail = await paymentDetailsService.GetPaymentDetailById(id);
            return Ok(orderDetail);
        }

        // POST api/<OrderDetailsController>
        [HttpPost(ApiEndPointConstant.PaymentDetail.PaymentDetailsEndpoint)]
        public async Task<IActionResult> Post([FromBody] CreatePaymentDetailsRequest createOrderPaymentRequest)
        {
            var order = await paymentDetailsService.CreatePaymentDetail(createOrderPaymentRequest);
            return Ok(order);
        }

        // PUT api/<OrderDetailsController>/5
        [HttpPut(ApiEndPointConstant.PaymentDetail.PaymentDetailEndpoint)]
        public async Task<IActionResult>  Put(string id)
        {
            bool isSuccessful = await paymentDetailsService.UpdatedPaymentDetailById(id);
            if (isSuccessful)
            {
                return Ok("Update  successful !");
            }
            return Ok("Update Failed");
        }

    }
}
