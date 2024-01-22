using Application.LoginFailureTrackerDetails.Commands.Request;
using Application.LoginFailureTrackerDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginFailureTrackerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginFailureTrackerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLoginFailureTrackerCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(new { Message = "LoginFailureTracker creation failed." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var loginfailuretrackers = await _mediator.Send(new GetAllLoginFailureTrackerQueryRequest());

            return Ok(loginfailuretrackers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var requestModel = new GetByIdLoginFailureTrackerQueryRequest { Id = id };
            var loginfailuretracker = await _mediator.Send(requestModel);

            return loginfailuretracker != null
                ? (IActionResult)Ok(loginfailuretracker)
                : NotFound(new { Message = "LoginFailureTracker not found." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLoginFailureTrackerCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "LoginFailureTracker updated successfully." });
            }

            return BadRequest(new { Message = "LoginFailureTracker update failed." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var requestModel = new DeleteLoginFailureTrackerCommandRequest { Id = id };
            var response = await _mediator.Send(requestModel);

            return response.IsSuccess
                ? (IActionResult)Ok(new { Message = "LoginFailureTracker deleted successfully." })
                : NotFound(new { Message = "LoginFailureTracker not found." });
        }
    }
}