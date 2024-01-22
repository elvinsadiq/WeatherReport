using Application.LoginFailureTrackerDetails.Queries.Request;
using Application.LoginFailureTrackerDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.LoginFailureTrackerDetails.Handlers.QueryHandlers
{
    public class GetByIdLoginFailureTrackerQueryHandler : IRequestHandler<GetByIdLoginFailureTrackerQueryRequest, GetByIdLoginFailureTrackerQueryResponse>
    {
        private readonly ILoginFailureTrackerRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdLoginFailureTrackerQueryHandler(ILoginFailureTrackerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdLoginFailureTrackerQueryResponse> Handle(GetByIdLoginFailureTrackerQueryRequest request, CancellationToken cancellationToken)
        {
            var loginfailuretracker = await _repository.FirstOrDefaultAsync(p => p.Id == request.Id);

            if (loginfailuretracker != null)
            {
                var response = _mapper.Map<GetByIdLoginFailureTrackerQueryResponse>(loginfailuretracker);
                return response;
            }

            return new GetByIdLoginFailureTrackerQueryResponse();
        }
    }
}