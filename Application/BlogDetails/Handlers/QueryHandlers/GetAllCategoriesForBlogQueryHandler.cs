using Application.BlogDetails.Queries.Request;
using Application.BlogDetails.Queries.Response;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BlogDetails.Handlers.QueryHandlers
{
    public class GetAllCategoriesForBlogQueryHandler : IRequestHandler<GetAllCategoriesForBlogRequest, List<GetAllCategoriesForBlogResponse>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllCategoriesForBlogQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetAllCategoriesForBlogResponse>> Handle(GetAllCategoriesForBlogRequest request, CancellationToken cancellationToken)
        {
            List<Category> categoriesWithBlogs = await _context.Categories.Include(category => category.Blogs)
                .ToListAsync(cancellationToken);

            var response = categoriesWithBlogs.Select(category => new GetAllCategoriesForBlogResponse
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                BlogCount = category.Blogs.Count
            }).ToList();
            return response;
        }
    }
}