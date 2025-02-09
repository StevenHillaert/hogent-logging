using LogItLikeItsHot.Shared.Features;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogItLikeItsHot.Barista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaristaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaristaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("menu")]
        public async Task<IActionResult> GetMenu()
        {
            // send mediatr request to get menu
            var query = new GetMenuQuery();
            var menu = await _mediator.Send(query);

            return Ok(menu);
        }

        [HttpPost("orders")]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderCommand placeOrderCommand)
        {
            // send mediatr request to place order
            var order = await _mediator.Send(placeOrderCommand);

            return Ok(order);
        }
    }
}
