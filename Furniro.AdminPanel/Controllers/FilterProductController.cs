using Application.GetProductDetails.Queries.Request;
using Application.GetProductDetails.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FilterProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetProductQueryResponse>>> FilterProducts([FromQuery] GetProductQueryRequest request)
        {
            var filteredProducts = await _mediator.Send(request);
            return Ok(filteredProducts);
        }
    }
}
