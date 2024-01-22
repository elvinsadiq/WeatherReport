using Application.ContactMessageDetails.Queries.Request;
using Application.ContactMessageDetails.Queries.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ContactMessageDetails.Handlers.QueryHandlers
{
    public class GetAllContactMessageQueryHandler : IRequestHandler<GetAllContactMessageQueryRequest, List<GetAllContactMessageQueryResponse>>
    {
        private readonly IContactMessageRepository _repository;
        private readonly IMapper _mapper;
        public GetAllContactMessageQueryHandler(IContactMessageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetAllContactMessageQueryResponse>> Handle(GetAllContactMessageQueryRequest request, CancellationToken cancellationToken)
        {
            List<ContactMessage> contactMessages = await _repository.GetAll(x => true).ToListAsync(cancellationToken: cancellationToken);
            if (contactMessages != null)
            {
                return _mapper.Map<List<GetAllContactMessageQueryResponse>>(contactMessages);
            }
            else
            {
                return new List<GetAllContactMessageQueryResponse>();
            }
        }
    }
}