using Application.ContactDetails.Commands.Request;
using Application.ContactDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;

namespace Application.ContactDetails.Handlers.CommandHandlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommandRequest, CreateContactCommandResponse>
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;
        public CreateContactCommandHandler(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CreateContactCommandResponse> Handle(CreateContactCommandRequest request, CancellationToken cancellationToken)
        {
            var contact = _mapper.Map<Contact>(request);

            await _repository.AddAsync(contact);
            await _repository.CommitAsync();

            return new CreateContactCommandResponse
            {
                IsSuccess = true,
                Message = "Contact created successfully"
            };
        }
    }
}