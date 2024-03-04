using BirthdayParty.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirthdayParty.WebApi.Controllers;

[Route("api/v1/discounts")]
public class DiscountController : BaseController<DiscountController>
{
    public DiscountController(ILogger<DiscountController> logger) : base(logger)
    {
    }

    [HttpGet]
    public Task<ActionResult<IEnumerable<Discount>>> Get()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<ActionResult<Discount>> Post()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public Task<ActionResult<Discount>> Put(string id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public Task<ActionResult<Discount>> Delete(string id)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public Task<ActionResult<Discount>> Get(string id)
    {
        throw new NotImplementedException();
    }
}