using Application.ContactDetails.Commands.Request;
using Application.ContactDetails.Queries.Request;
using Application.ContactDetails.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateContactCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(new { Message = "Contact created successfully." }) : throw new Exception();
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllContactQueryResponse>>> Get()
        {
            var contacts = await _mediator.Send(new GetAllContactQueryRequest());
            return contacts != null ? Ok(contacts) : throw new Exception();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContactCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(new { Message = "Contact updated successfully." }) : throw new Exception();
        }
    }
}