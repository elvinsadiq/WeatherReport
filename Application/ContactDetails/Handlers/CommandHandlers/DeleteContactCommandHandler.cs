using Application.ContactDetails.Commands.Request;
using Application.ContactDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;

namespace Application.ContactDetails.Handlers.CommandHandlers
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommandRequest, DeleteContactCommandResponse>
    {
        private readonly IContactRepository _repository;
        public DeleteContactCommandHandler(IContactRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteContactCommandResponse> Handle(DeleteContactCommandRequest request, CancellationToken cancellationToken)
        {
            var contact = await _repository.GetAsync(x => x.Id == request.Id);
            _repository.Remove(contact);
            await _repository.CommitAsync();

            return new DeleteContactCommandResponse
            {
                IsSuccess = true,
                Message = "Contact deleted successfully"
            };
        }
    }
}