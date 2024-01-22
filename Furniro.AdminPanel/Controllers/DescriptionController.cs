using Application.DescriptionDetails.Commands.Request;

using Application.ProductDetails.Commands.Request;
using Application.ProductDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DescriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteDescription([FromBody] DeleteDescriptionCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return response != null
           ? (IActionResult)Ok(response)
           : NotFound(new { Message = "Description not found." });
        }
    }
}
