using Application.ContactMessageDetails.Queries.Request;
using Application.ContactMessageDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.ContactMessageDetails.Handlers.QueryHandlers
{
    public class GetByIdContactMessageQueryHandler : IRequestHandler<GetByIdContactMessageQueryRequest, GetByIdContactMessageQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactMessageRepository _repository;
        public GetByIdContactMessageQueryHandler(IMapper mapper, IContactMessageRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<GetByIdContactMessageQueryResponse> Handle(GetByIdContactMessageQueryRequest request, CancellationToken cancellationToken)
        {
            var contactMessage = await _repository.GetAsync(x => x.Id == request.Id);
            return _mapper.Map<GetByIdContactMessageQueryResponse>(contactMessage);
        }
    }
}