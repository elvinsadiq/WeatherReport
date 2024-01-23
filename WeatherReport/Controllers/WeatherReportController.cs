using Application.WeatherReportDetails.Commands.Request;
using Application.WeatherReportDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateWeatherReportCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var weatherreports = await _mediator.Send(new GetAllWeatherReportQueryRequest());

            return Ok(weatherreports);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var requestModel = new GetByIdWeatherReportQueryRequest { Id = id };
            var weatherreport = await _mediator.Send(requestModel);

            return weatherreport != null
                ? (IActionResult)Ok(weatherreport)
                : NotFound(new { Message = "WeatherReport not found." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateWeatherReportCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete([FromBody] DeleteWeatherReportCommandRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}