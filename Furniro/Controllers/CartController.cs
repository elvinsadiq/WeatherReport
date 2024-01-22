using Application.AppUserCartDetails.Commands.Request;
using Application.CartDetails.AddToCartDetails.Commands.Request;
using Application.CartDetails.AddToCartDetails.Queries.Request;
using Application.CartDetails.RemoveFromCartDetails.Commands.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addToCart")]
       // [Authorize(Roles = "AppUser, Admin")]
        public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Success)
            {
                return Ok(response);
            }

            throw new Exception(response.Message);
        }

        [HttpDelete("remove")]
     //   [Authorize(Roles = "AppUser, Admin")]
        public async Task<IActionResult> RemoveFromCart([FromBody] RemoveFromCartRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.Success)
            {
                return Ok(new { Success = true, Message = response.Message });
            }

            throw new Exception(response.Message);
        }

        [HttpPost("ClearCart")]
       // [Authorize(Roles = "AppUser, Admin")]
        public async Task<IActionResult> ClearUserCart([FromBody] ClearAppUserCartCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = response.Message });
            }

            throw new Exception(response.Message);
        }

        [HttpGet("getAllCartItems/{userId}")]
       // [Authorize(Roles = "AppUser, Admin")]
        public async Task<IActionResult> GetAllCartItems(int userId)
        {
            var request = new GetAllCartItemsRequest { UserId = userId };
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
