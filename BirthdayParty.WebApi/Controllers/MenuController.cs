using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Payload.Request.Discounts;
using BirthdayParty.Domain.Payload.Request.Menus;
using BirthdayParty.Services.Service;
using BirthdayParty.WebApi.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        [HttpGet(ApiEndPointConstant.Menu.MenuEndpoint)]
        public async Task<IActionResult> GetById(string id)
        {
            var menu = await menuService.GetMenuById(id);
            return Ok(menu);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMenuRequest createMenuRequest)
        {
            var menu = await menuService.CreateMenu(createMenuRequest);
            return Ok(menu);
        }

        [HttpGet(ApiEndPointConstant.Menu.MenusEndpoint)]
        public async Task<IActionResult> GetDiscounts([FromQuery] int page, [FromQuery] int size)
        {
            var menu = await menuService.GetMenus(page, size);
            return Ok(menu);
        }

        [HttpPut(ApiEndPointConstant.Menu.MenuEndpoint)]
        public async Task<IActionResult> Put(string id)
        {
            bool isSuccessful = await menuService.UpdateMenuById(id);
            if (isSuccessful)
            {
                return Ok("Update  successful !");
            }
            return Ok("Update Failed");
        }
        [HttpDelete(ApiEndPointConstant.Menu.MenuEndpoint)]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("Menu Id is null or empty");
                }

                bool isDeleted = await menuService.UpdateMenuById(id);

                if (isDeleted)
                {
                    return Ok("Delete successful!");
                }
                else
                {
                    return NotFound("Menu not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
