using Application.HomeDetails.Queries.Request;
using Application.HomeDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.HomeDetails.Handlers.QueryHandlers
{
    public class GetAllHomeQueryHandler : IRequestHandler<GetAllHomeQueryRequest, List<GetAllHomeQueryResponse>>
    {
        private readonly IHomeRepository _repository;
        private readonly IMapper _mapper;
        public GetAllHomeQueryHandler(IHomeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllHomeQueryResponse>> Handle(GetAllHomeQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Home>? homes = _repository.GetAll(x => true).Include(b => b.HomeImages).ToList();
            if (homes != null)
            {
                List<GetAllHomeQueryResponse> response = _mapper.Map<List<GetAllHomeQueryResponse>>(homes);
                return response;
            }
            else
            {
                return new List<GetAllHomeQueryResponse>();
            }
        }
    }
}