using BirthdayParty.Application.Service;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Request.OrderItems;
using BirthdayParty.Services.Service;
using BirthdayParty.WebApi.Constants;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthdayParty.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemsService orderItemsService;

        public OrderItemsController(IOrderItemsService orderItemsService)
        {
            this.orderItemsService = orderItemsService;
        }

        // GET: api/<OrderItemsController>
        [HttpGet(ApiEndPointConstant.OrderItem.OrderItemsEndpoint)]
        public async Task<IActionResult> Get([FromQuery] int page, [FromQuery] int size)
        {
            var orderDetail = await orderItemsService.GetOrderItems(page, size);
            return Ok(orderDetail);
        }

        // GET api/<OrderItemsController>/5
        [HttpGet(ApiEndPointConstant.OrderItem.OrderItemEndpoint)]
        public async Task<IActionResult> GetById(string id)
        {
            var orderDetail = await orderItemsService.GetOrderItem(id);
            return Ok(orderDetail);
        }

        // POST api/<OrderItemsController>
        [HttpPost(ApiEndPointConstant.OrderItem.OrderItemsEndpoint)]
        public async Task<IActionResult> Post([FromBody] CreateOrderItemsRequest createOrderItemsRequest)
        {
            var order = await orderItemsService.CreateOrderItem(createOrderItemsRequest);
            return Ok(order);
        }

        // PUT api/<OrderItemsController>/5
        [HttpPut(ApiEndPointConstant.OrderItem.OrderItemEndpoint)]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateOrderItemsRequest updateOrderItemsRequest)
        {

            bool isSuccessful = await orderItemsService.UpdateOrderItem(id, updateOrderItemsRequest);
            if (isSuccessful)
            {
                return Ok("Update  successful !");
            }
            return Ok("Update Failed");
        }

        //// DELETE api/<OrderItemsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
