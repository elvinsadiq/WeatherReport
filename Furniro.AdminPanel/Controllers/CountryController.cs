using Application.CheckoutDetails.CountryDetails.Commands.Request;
using Application.CheckoutDetails.CountryDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCountryCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(new { Message = "Country creation failed." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _mediator.Send(new GetAllCountryQueryRequest());

            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var requestModel = new GetByIdCountryQueryRequest { Id = id };
            var country = await _mediator.Send(requestModel);

            return country != null
                ? (IActionResult)Ok(country)
                : NotFound(new { Message = "Country not found." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCountryCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Country updated successfully." });
            }

            return BadRequest(new { Message = "Country update failed." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var requestModel = new DeleteCountryCommandRequest { Id = id };
            var response = await _mediator.Send(requestModel);

            return response.IsSuccess
                ? (IActionResult)Ok(new { Message = "Country deleted successfully." })
                : NotFound(new { Message = "Country not found." });
        }
    }
}
