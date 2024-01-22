using Application.BlogDetails.Commands.Request;
using Application.BlogDetails.Queries.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateBlogCommandRequest request)
        {
            _ = await _mediator.Send(request);

            return Ok();
            throw new Exception();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllBlogQueryRequest request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var blog = await _mediator.Send(new GetByIdBlogQueryRequest { Id = id });
            return blog != null
                ? Ok(blog) : throw new Exception();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateBlogCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.IsSuccess)
            {
                return Ok(new { Message = "Blog updated successfully." });
            }
            throw new Exception();
        }

        [HttpPut("blog-image")]
        public async Task<IActionResult> UpdateImage([FromForm] UpdateBlogImageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.IsSuccess)
            {
                return Ok(new { Message = "Blog image updated successfully." });
            }
            throw new Exception();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBlogCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return response != null
           ? Ok(response)
           : throw new Exception();
        }
    }
}