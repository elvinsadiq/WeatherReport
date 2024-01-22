using Application.BlogDetails.Queries.Request;
using Application.BlogDetails.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetAllBlogForUserQueryResponse>>> Get([FromQuery] GetAllBlogForUserQueryRequest request)
        {
                var response = await _mediator.Send(request);
                return Ok(response) ?? throw new Exception();
        }

        [HttpGet("blog-categories")]
        public async Task<ActionResult<List<GetAllCategoriesForBlogResponse>>> GetCategory()
        {
            var requestModel = new GetAllCategoriesForBlogRequest();
            var blogs = await _mediator.Send(requestModel);
            return blogs ?? throw new Exception();
        }

        [HttpGet("recent-posts")]
        public async Task<ActionResult<List<GetAllRecentPostsQueryResponse>>> RecentPosts()
        {
            var requestModel = new GetAllRecentPostsQueryRequest();
            var recentPosts = await _mediator.Send(requestModel);
            return recentPosts == null ? throw new Exception() : (ActionResult<List<GetAllRecentPostsQueryResponse>>)recentPosts;
        }
    }
}