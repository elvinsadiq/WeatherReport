using Application.ContactMessageDetails.Commands.Request;
using Application.ContactMessageDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;

namespace Application.ContactMessageDetails.Handlers.CommandHandlers
{
    public class UpdateContactMessageCommandHandler : IRequestHandler<UpdateContactMessageCommandRequest, UpdateContactMessageCommandResponse>
    {
        private readonly IContactMessageRepository _repository;
        public UpdateContactMessageCommandHandler(IContactMessageRepository repository)
        {
            _repository = repository;
        }
        public async Task<UpdateContactMessageCommandResponse> Handle(UpdateContactMessageCommandRequest request, CancellationToken cancellationToken)
        {
            var contactMessage = await _repository.GetAsync(x => x.Id == request.Id);
            await _repository.UpdateAsync(contactMessage);

            return new UpdateContactMessageCommandResponse
            {
                IsSuccess = true,
                Message = "Contact message updated successfully"
            };
        }
    }
}