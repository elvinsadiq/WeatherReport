using Application.DistrictDetails.Commands.Request;
using Application.DistrictDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DistrictController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDistrictCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] UploadDistrictCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var districts = await _mediator.Send(new GetAllDistrictQueryRequest());

            return Ok(districts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var requestModel = new GetByIdDistrictQueryRequest { Id = id };
            var district = await _mediator.Send(requestModel);

            return district != null
                ? (IActionResult)Ok(district)
                : NotFound(new { Message = "District not found." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDistrictCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteDistrictCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}