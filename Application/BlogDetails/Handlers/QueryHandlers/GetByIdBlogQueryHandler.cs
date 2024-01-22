using Application.BlogDetails.Queries.Request;
using Application.BlogDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.BlogDetails.Handlers.QueryHandlers
{
    public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQueryRequest, GetByIdBlogQueryResponse>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;
        public GetByIdBlogQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetByIdBlogQueryResponse> Handle(GetByIdBlogQueryRequest request, CancellationToken cancellationToken)
        {
            var blog = _repository.Get(x => x.Id == request.Id, "Category", "User", "BlogImages", "User.AppUserRole") ?? throw new Exception();
            var response = _mapper.Map<GetByIdBlogQueryResponse>(blog);
            return response;
        }
    }
}