using Application.CheckoutDetails.ProvinceDetails.Commands.Request;
using Application.CheckoutDetails.ProvinceDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProvinceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProvinceCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(new { Message = "Province creation failed." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var province = new GetAllProvinceQueryRequest();

            var response = await _mediator.Send(province);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var requestModel = new GetByIdProvinceQueryRequest { Id = id };
            var province = await _mediator.Send(requestModel);

            return province != null
                ? (IActionResult)Ok(province)
                : NotFound(new { Message = "Province not found." });
        }


        [HttpGet("GetRelatedProvince/{countryId}")]
        public async Task<IActionResult> GetRelatedProvince(int countryId)
        {
            var requestModel = new GetRelatedProvinceQueryRequest { CountryId = countryId };
            var provinces = await _mediator.Send(requestModel);

            return Ok(provinces);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProvinceCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Province updated successfully." });
            }

            return BadRequest(new { Message = "Province update failed." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var requestModel = new DeleteProvinceCommandRequest { Id = id };
            var response = await _mediator.Send(requestModel);

            return response.IsSuccess
                ? (IActionResult)Ok(new { Message = "Province deleted successfully." })
                : NotFound(new { Message = "Province not found." });
        }
    }
}