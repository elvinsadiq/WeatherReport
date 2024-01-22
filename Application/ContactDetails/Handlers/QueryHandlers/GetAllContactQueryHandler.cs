using Application.ContactDetails.Queries.Request;
using Application.ContactDetails.Queries.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ContactDetails.Handlers.QueryHandlers
{
    public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQueryRequest, List<GetAllContactQueryResponse>>
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;
        public GetAllContactQueryHandler(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllContactQueryResponse>> Handle(GetAllContactQueryRequest request, CancellationToken cancellationToken)
        {
            List<Contact> contacts = await _repository.GetAll(x => true).ToListAsync(cancellationToken: cancellationToken);
            return _mapper.Map<List<GetAllContactQueryResponse>>(contacts);
        }
    }
}