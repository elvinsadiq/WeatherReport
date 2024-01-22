// CountryController.cs
using Application.CheckoutDetails.CountryDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "AppUser, Admin")]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _mediator.Send(new GetAllCountryQueryRequest());

            return Ok(countries);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "AppUser, Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var requestModel = new GetByIdCountryQueryRequest { Id = id };
            var country = await _mediator.Send(requestModel);

            return country != null
                ? (IActionResult)Ok(country)
                : NotFound(new { Message = "Country not found." });
        }
    }
}
