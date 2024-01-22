using Application.HomeDetails.Queries.Request;
using Application.HomeDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.HomeDetails.Handlers.QueryHandlers
{
    public class GetByIdHomeQueryHandler : IRequestHandler<GetByIdHomeQueryRequest, GetByIdHomeQueryResponse>
    {
        private readonly IHomeRepository _repository;
        private readonly IMapper _mapper;
        public GetByIdHomeQueryHandler(IHomeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetByIdHomeQueryResponse> Handle(GetByIdHomeQueryRequest request, CancellationToken cancellationToken)
        {

            var home = await _repository.FirstOrDefaultAsync(p => p.Id == request.Id, "HomeImages");

            if (home != null)
            {
                var response = _mapper.Map<GetByIdHomeQueryResponse>(home);
                return response;
            }

            return new GetByIdHomeQueryResponse();
        }
    }
}