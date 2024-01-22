using Application.BlogDetails.Queries.Request;
using Application.BlogDetails.Queries.Response;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BlogDetails.Handlers.QueryHandlers
{
    public class GetAllBlogForUserQueryHandler : IRequestHandler<GetAllBlogForUserQueryRequest, List<GetBlogListResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;
        public GetAllBlogForUserQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<GetBlogListResponse>> Handle(GetAllBlogForUserQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Blog> blogsQuery = _context.Blogs.Include(b => b.BlogImages).Include(b => b.Category).Include(b => b.User).ThenInclude(b => b.AppUserRole)
                 .Where(x =>
                 (request.Prompt == null || x.Header.ToLower().Contains(request.Prompt.ToLower())) &&
                 (request.CategoryId == null || x.CategoryId == request.CategoryId))
                 .AsQueryable();

            int blogsCount = (await blogsQuery.ToListAsync(cancellationToken: cancellationToken)).Count;
            var responseList = _mapper.Map<List<GetAllBlogForUserQueryResponse>>(blogsQuery.Skip((request.Page - 1) * request.ShowMore.Take).Take(request.ShowMore.Take));
            var blogListResponse = new List<GetBlogListResponse>
                    {
                        new GetBlogListResponse
                        {
                            TotalBlogCount = blogsCount,
                            Blogs = responseList
                        }
                    };
            return blogListResponse;
        }
    }
}