using Application.LoginFailureTrackerDetails.Queries.Request;
using Application.LoginFailureTrackerDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.LoginFailureTrackerDetails.Handlers.QueryHandlers
{
    public class GetAllLoginFailureTrackerQueryHandler : IRequestHandler<GetAllLoginFailureTrackerQueryRequest, List<GetAllLoginFailureTrackerQueryResponse>>
    {
        private readonly ILoginFailureTrackerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllLoginFailureTrackerQueryHandler(ILoginFailureTrackerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAllLoginFailureTrackerQueryResponse>> Handle(GetAllLoginFailureTrackerQueryRequest request, CancellationToken cancellationToken)
        {
            var loginfailuretrackers = _repository.GetAll(x => true);

            if (loginfailuretrackers != null)
            {
                List<GetAllLoginFailureTrackerQueryResponse> response = _mapper.Map<List<GetAllLoginFailureTrackerQueryResponse>>(loginfailuretrackers);
                return response;
            }
            else
            {
                return new List<GetAllLoginFailureTrackerQueryResponse>();
            }
        }
    }
}