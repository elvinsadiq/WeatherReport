using Application.FavoriteDetails.Commands.Request;
using Application.FavoriteDetails.Queries.Request;
using Application.FavoriteDetails.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "AppUser, Admin")]
    public class FavoriteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FavoriteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetFavoritesByUserIdQueryResponse>>> GetFavoritesByUserId([FromQuery] GetFavoritesByUserIdQueryRequest request)
        {
            var favorites = await _mediator.Send(request);
            return Ok(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(AddToFavoriteCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.IsSuccess)
            {
                return Ok();
            }
            throw new Exception();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromFavorites(RemoveFromFavoriteCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.IsSuccess)
            {
                return Ok();
            }
            throw new Exception();
        }
    }
}