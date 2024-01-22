using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.CategoryDetails.Commands.Request;
using Application.CategoryDetails.Commands.Response;
using MediatR;
using Application.CategoryDetails.Queries.Request;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Category created successfully." });
            }

            return BadRequest(new { Message = "Category creation failed." });
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCategory([FromBody] DeleteCategoryCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Category deleted successfully." });
            }

            return NotFound(new { Message = "Category not found or deletion failed." });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            var response = await _mediator.Send(request);

            if (response.IsSuccess)
            {
                return Ok(new { Message = "Category updated successfully." });
            }

            return BadRequest(new { Message = "Category update failed." });
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoryQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetCategoryById([FromQuery] GetByIdCategoryQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return response != null
            ? (IActionResult)Ok(response)
            : NotFound(new { Message = "Category not found." });
        }
    }
}
