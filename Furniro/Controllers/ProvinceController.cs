using Application.CheckoutDetails.ProvinceDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "AppUser, Admin")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProvinceController(IMediator mediator)
        {
            _mediator = mediator;
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
    }
}