using Microsoft.AspNetCore.Mvc;
using BirthdayParty.Application.Service;
using BirthdayParty.WebApi.Constants;
using BirthdayParty.Services.Service;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Request.Accounts;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthdayParty.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            this.orderDetailsService = orderDetailsService;
        }

        // GET: api/<OrderDetailsController>
        [HttpGet(ApiEndPointConstant.OrderDetail.OrderDetailsEndpoint)]
        public async Task<IActionResult> GetOrderDetails([FromQuery]int page, [FromQuery]int size)
        { 
            var orderDetail = await orderDetailsService.GetOrderDetails(page, size);
            return Ok(orderDetail);
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet(ApiEndPointConstant.OrderDetail.OrderDetailEndpoint)]
        public async Task<IActionResult> GetById(string id)
        {
            var orderDetail = await orderDetailsService.GetOrderDetailById(id);
            return Ok(orderDetail);
        }

        // POST api/<OrderDetailsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOrderDetailRequest createOrderDetailRequest)
        {
            var order = await orderDetailsService.CreateOrderDetail(createOrderDetailRequest);
            return Ok(order);
        }

        // PUT api/<OrderDetailsController>/5
        [HttpPut(ApiEndPointConstant.OrderDetail.OrderDetailEndpoint)]
        public async Task<IActionResult>  Put(string id)
        {
            bool isSuccessful = await orderDetailsService.UpdatedOrderDetailById(id);
            if (isSuccessful)
            {
                return Ok("Update  successful !");
            }
            return Ok("Update Failed");
        }

    }
}
