using Application.ContactDetails.Commands.Request;
using Application.ContactDetails.Commands.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.ContactDetails.Handlers.CommandHandlers
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommandRequest, UpdateContactCommandResponse>
    {
        private readonly IContactRepository _repository;
        private readonly IMapper _mapper;
        public UpdateContactCommandHandler(IContactRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UpdateContactCommandResponse> Handle(UpdateContactCommandRequest request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, contact);

            await _repository.UpdateAsync(contact);

            return new UpdateContactCommandResponse
            {
                IsSuccess = true,
                Message = "Contact updated successfully"
            };
        }
    }
}