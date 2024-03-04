using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Payload.Request.Customers;
using BirthdayParty.Domain.Payload.Request.HostParties;
using BirthdayParty.WebApi.Constants;
using BirthdayParty.WebApi.Enums;
using BirthdayParty.WebApi.Validators;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController<CustomerController>
    {
        private readonly ICustomerService _CustomerService;
        public CustomerController(ILogger<CustomerController> logger, ICustomerService CustomerService) : base(logger)
        {
            _CustomerService = CustomerService;
        }

        [CustomAuthorize(RoleEnum.admin)]
        [HttpGet(ApiEndPointConstant.Customer.CustomersEndpoint)]
        public async Task<IActionResult> GetCustomers([FromQuery] int page, [FromQuery] int size)
        {
            var customers = await _CustomerService.GetCustomers(page, size);
            return Ok(customers);
        }

        [HttpGet(ApiEndPointConstant.Customer.CustomerEndpoint)]
        public async Task<IActionResult> GetCustomer(string id)
        {
            var Customer = await _CustomerService.GetCustomerById(id);
            return Ok(Customer);
        }

        /*[HttpPost(ApiEndPointConstant.Customer.CustomersEndpoint)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest createCustomerRequest)
        {
            var CustomerId = _CustomerService.CreateCustomer(createCustomerRequest);
            return Ok(CustomerId);
        }*/

        [HttpPut(ApiEndPointConstant.Customer.CustomerEndpoint)]
        public async Task<IActionResult> UpdateCustomer(string id
            , [FromBody] UpdateCustomerRequest updateCustomerRequest)
        {
            bool isSuccessful = await _CustomerService.UpdateCustomerById(id, updateCustomerRequest);
            if (isSuccessful)
            {
                return Ok("Update  successful !");
            }
            return Ok("Update Failed");
        }

        [HttpDelete(ApiEndPointConstant.Customer.CustomerEndpoint)]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            UpdateCustomerRequest updateCustomerRequest = new UpdateCustomerRequest()
            {
                IsDeleted = true
            };
            bool isSuccessful = await _CustomerService.UpdateCustomerById(id, updateCustomerRequest);
            if (isSuccessful)
            {
                return Ok("delete  successful !");
            }
            return Ok("delete Failed");
        }
    }
}
