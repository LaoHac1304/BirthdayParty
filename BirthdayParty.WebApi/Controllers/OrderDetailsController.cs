using Microsoft.AspNetCore.Mvc;
using BirthdayParty.Application.Service;
using BirthdayParty.WebApi.Constants;
using BirthdayParty.Services.Service;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Domain.Payload.Request.Accounts;
using System.Security.Claims;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Response.Customers;
using BirthdayParty.Domain.Payload.Response.OrderDetails;
using BirthdayParty.WebApi.Enums;
using BirthdayParty.WebApi.Validators;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthdayParty.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService orderDetailsService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICustomerService _customerService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService, IHttpContextAccessor httpContextAccessor, ICustomerService customerService)
        {
            this.orderDetailsService = orderDetailsService;
            _httpContextAccessor = httpContextAccessor;
            _customerService = customerService;

        }

        // GET: api/<OrderDetailsController>
        [HttpGet(ApiEndPointConstant.OrderDetail.OrderDetailsEndpoint)]
        public async Task<ActionResult<IPaginate<GetOrderDetailResponse>>> GetOrderDetails([FromQuery] GetOrderDetailsRequest request)
        { 
            var orderDetail = await orderDetailsService.GetOrderDetails(request);
            return Ok(orderDetail);
        }

        // GET api/<OrderDetailsController>/5
        [HttpGet(ApiEndPointConstant.OrderDetail.OrderDetailEndpoint)]
        public async Task<IActionResult> GetById(string id)
        {
            var orderDetail = await orderDetailsService.GetOrderDetailById(id);
            return Ok(orderDetail);
        }

        [HttpGet(ApiEndPointConstant.OrderDetail.OwnOrderDetailsEndpoint)]
        [CustomAuthorize(RoleEnum.customer)]
        public async Task<IActionResult> GetMyOrderDetail([FromQuery] int page, [FromQuery] int size)
        {
            var currentUser = _httpContextAccessor.HttpContext.User;
            if (currentUser is null) return Unauthorized("Email Or Role Invalid!!!");

            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = currentUser.FindFirst(ClaimTypes.Email)?.Value;
            var role = currentUser.FindFirst(ClaimTypes.Role)?.Value;
            if (role is null || userId is null || email is null) return Unauthorized("Email Or Role Invalid!!!");
            if (role.Equals("customer"))
            {
                GetCustomerResponse customerResponse = await _customerService.GetCustomerByAccountId(userId);
                if (customerResponse is null)
                    return Unauthorized();
                //var orderDetail = await orderDetailsService.GetOrderDetailsByCustomerId(customerResponse.Id, page, size);
                var orderDetail = await orderDetailsService.GetOrderDetails(new GetOrderDetailsRequest { 
                    CustomerId = customerResponse.Id,
                    Page = page,
                    Size = size,
                });
                return Ok(orderDetail);
            }
            else return Unauthorized();


        }

        // POST api/<OrderDetailsController>
        [HttpPost(ApiEndPointConstant.OrderDetail.OrderDetailsEndpoint)]
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
