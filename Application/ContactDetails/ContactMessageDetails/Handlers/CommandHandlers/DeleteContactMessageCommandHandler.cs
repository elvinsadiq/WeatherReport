using Application.ContactMessageDetails.Commands.Request;
using Application.ContactMessageDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;

namespace Application.ContactMessageDetails.Handlers.CommandHandlers
{
    public class DeleteContactMessageCommandHandler : IRequestHandler<DeleteContactMessageCommandRequest, DeleteContactMessageCommandResponse>
    {
        private readonly IContactMessageRepository _repository;
        public DeleteContactMessageCommandHandler(IContactMessageRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteContactMessageCommandResponse> Handle(DeleteContactMessageCommandRequest request, CancellationToken cancellationToken)
        {
            var contactMessage = await _repository.GetAsync(x => x.Id == request.Id);
            _repository.Remove(contactMessage);
            await _repository.CommitAsync();

            return new DeleteContactMessageCommandResponse
            {
                IsSuccess = true,
                Message = "Contact message deleted successfully"
            };
        }
    }
}