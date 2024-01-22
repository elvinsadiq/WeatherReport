using Application.GetProductDetails.Queries.Request;
using Application.GetProductDetails.Queries.Response;
using Application.NewProductDetails.Queries.Request;
using Application.ProductDescriptionDetails.Queries.Request;
using Application.ProductPageDetails.Queries.Request;
using Application.RelatedCategoryProductDetails.Queries.Request;
using Application.RelatedProductsDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("RelatedProducts")]
        public async Task<IActionResult> GetRelatedProducts([FromQuery] GetRelatedProductsQueryRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("Products")]
        public async Task<ActionResult<List<GetProductQueryResponse>>> GetProducts([FromQuery] GetProductQueryRequest request)
        {
            var filteredProducts = await _mediator.Send(request);
            return Ok(filteredProducts);
        }

        [HttpGet("getById/ProductPage")]
        public async Task<IActionResult> GetProductPageById([FromQuery] GetByIdProductPageQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return response != null
                ? (IActionResult)Ok(response)
                : NotFound(new { Message = "Product not found." });
        }

        [HttpGet("getById/Description")]
        public async Task<IActionResult> GetProductDescriptionById([FromQuery] GetByIdProductDescriptionQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return response != null
                ? (IActionResult)Ok(response)
                : NotFound(new { Message = "Description not found." });
        }

        //[HttpGet("NewProducts")]
        //public async Task<IActionResult> GetNewProducts([FromQuery] GetNewProductsQueryRequest request)
        //{
        //    try
        //    {
        //        var response = await _mediator.Send(request);
        //        return Ok(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}

        [HttpGet("GetRelatedCategoryProducts")]
        public async Task<IActionResult> GetRelatedCategoryProducts([FromQuery] GetRelatedCategoryProductQueryRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
