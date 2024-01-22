using Application.BlogDetails.Queries.Request;
using Application.BlogDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BlogDetails.Handlers.QueryHandlers
{
    public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQueryRequest, List<GetAllBlogQueryResponse>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;
        public GetAllBlogQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllBlogQueryResponse>> Handle(GetAllBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetAll(x => true).Include(b => b.BlogImages).Include(b => b.Category).Include(b => b.User).ThenInclude(m => m.AppUserRole).ToListAsync(cancellationToken: cancellationToken);
            var response = _mapper.Map<List<GetAllBlogQueryResponse>>(blogs.Skip((request.Page - 1) * request.ShowMore.Take).Take(request.ShowMore.Take));

            PaginationListDto<GetAllBlogQueryResponse> model = new(response, request.Page, request.ShowMore.Take, blogs.Count);

            if (blogs != null)
            {
                return model.Items;
            }
            else
            {
                return new List<GetAllBlogQueryResponse>();
            }
        }
    }
}