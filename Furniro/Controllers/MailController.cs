using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Handlers.CommandHandlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MailController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[HttPost]
        //public async Task<IActionResult> Mail([FromQuery] SendMailRequest request)
        //{
        //    if (request!=null)
        //    { return Ok(await _mediator.Send(request)); }
        //    return BadRequest(await _mediator.Send(request));
        //}
    }
}