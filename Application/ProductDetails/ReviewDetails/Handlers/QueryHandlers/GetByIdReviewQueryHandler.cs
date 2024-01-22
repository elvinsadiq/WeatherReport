using Application.ReviewDetails.Queries.Request;
using Application.ReviewDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.ReviewDetails.Handlers.QueryHandlers
{
    public class GetByIdReviewQueryHandler : IRequestHandler<GetByIdReviewQueryRequest, GetByIdReviewQueryResponse>
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdReviewQueryHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdReviewQueryResponse> Handle(GetByIdReviewQueryRequest request, CancellationToken cancellationToken)
        {
            var review = await _repository.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (review != null)
            {
                var response = _mapper.Map<GetByIdReviewQueryResponse>(review);
                return response;
            }

            return new GetByIdReviewQueryResponse();
        }
    }
}