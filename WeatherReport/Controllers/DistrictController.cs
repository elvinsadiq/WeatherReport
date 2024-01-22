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
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(new { Message = "District creation failed." });
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
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "District updated successfully." });
            }

            return BadRequest(new { Message = "District update failed." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var requestModel = new DeleteDistrictCommandRequest { Id = id };
            var response = await _mediator.Send(requestModel);

            return response.IsSuccess
                ? (IActionResult)Ok(new { Message = "District deleted successfully." })
                : NotFound(new { Message = "District not found." });
        }
    }
}