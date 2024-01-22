using Application.BlogDetails.Queries.Request;
using Application.BlogDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BlogDetails.Handlers.QueryHandlers
{
    public class GetAllRecentPostsQueryHandler : IRequestHandler<GetAllRecentPostsQueryRequest, List<GetAllRecentPostsQueryResponse>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;
        public GetAllRecentPostsQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllRecentPostsQueryResponse>> Handle(GetAllRecentPostsQueryRequest request, CancellationToken cancellationToken)
        {
            var blogs = await _repository.GetAll(x => true).Include(b => b.BlogImages).OrderByDescending(o => o.CreatedDate).Take(5)
                .ToListAsync(cancellationToken: cancellationToken);
            if (blogs == null)
            {
                throw new Exception();
            }
            else
            {
                var result = _mapper.Map<List<GetAllRecentPostsQueryResponse>>(blogs);
                return result;
            }
        }
    }
}