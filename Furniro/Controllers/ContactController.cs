using Application.ContactDetails.Queries.Request;
using Application.ContactDetails.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllContactQueryResponse>>> Get()
        {
            var contacts = await _mediator.Send(new GetAllContactQueryRequest());
            return contacts ?? throw new Exception();
        }
    }
}