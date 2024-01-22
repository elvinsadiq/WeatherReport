using Application.Commands.Request;
using Application.ContactMessageDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;

namespace Application.ContactMessageDetails.Handlers.CommandHandlers
{
    public class CreateContactMessageCommandHandler : IRequestHandler<CreateContactMessageCommandRequest, CreateContactMessageCommandResponse>
    {
        private readonly IContactMessageRepository _repository;
        private readonly IMapper _mapper;
        private readonly IAppUserRepository _appUserRepository;
        public CreateContactMessageCommandHandler(IContactMessageRepository repository, IMapper mapper, IAppUserRepository appUserRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _appUserRepository = appUserRepository;
        }
        public async Task<CreateContactMessageCommandResponse> Handle(CreateContactMessageCommandRequest request, CancellationToken cancellationToken)
        {
            //var user = _appUserRepository.Get(x => true);
            var contactMessage = _mapper.Map<ContactMessage>(request);
            contactMessage.UserId = request.UserId;
            await _repository.AddAsync(contactMessage);
            await _repository.CommitAsync();

            return new CreateContactMessageCommandResponse
            {
                IsSuccess = true,
                Message = "Contact message created successfully"
            };
        }
    }
}