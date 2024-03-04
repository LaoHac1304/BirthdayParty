using BirthdayParty.Application.Service;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Payload.Request.Discounts;
using BirthdayParty.Domain.Payload.Request.OrderDetails;
using BirthdayParty.Services.Service;
using BirthdayParty.WebApi.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService discountService;

        public DiscountController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }
        [HttpGet(ApiEndPointConstant.Discount.DiscountEndpoint)]
        public async Task<IActionResult> GetById(string id)
        {
            var discount = await discountService.GetDiscountById(id);
            return Ok(discount);
        }


        [HttpPost(ApiEndPointConstant.Discount.DiscountsEndpoint)]
        public async Task<IActionResult> Post([FromBody] CreateDiscountRequest createDiscountRequest)
        {
            var discount = await discountService.CreateDiscount(createDiscountRequest);
            return Ok(discount);
        }

        [HttpGet(ApiEndPointConstant.Discount.DiscountsEndpoint)]
        public async Task<IActionResult> GetDiscounts([FromQuery] int page, [FromQuery] int size)
        {
            var discount = await discountService.GetDiscounts(page, size);
            return Ok(discount);
        }

        [HttpPut(ApiEndPointConstant.Discount.DiscountEndpoint)]
        public async Task<IActionResult> Put(string id)
        {
            bool isSuccessful = await discountService.UpdateDiscountById(id);
            if (isSuccessful)
            {
                return Ok("Update  successful !");
            }
            return Ok("Update Failed");
        }
        [HttpDelete(ApiEndPointConstant.Discount.DiscountEndpoint)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("Discount Id is null or empty");
                }

                bool isDeleted = await discountService.UpdateDiscountById(id);

                if (isDeleted)
                {
                    return Ok("Delete successful!");
                }
                else
                {
                    return NotFound("Discount not found");
                }
            }
            catch (Exception ex)
            {           
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
