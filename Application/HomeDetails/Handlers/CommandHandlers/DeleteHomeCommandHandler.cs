using Application.HomeDetails.Commands.Request;
using Application.HomeDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;

namespace Application.HomeDetails.Handlers.CommandHandlers
{
    public class DeleteHomeCommandHandler : IRequestHandler<DeleteHomeCommandRequest, DeleteHomeCommandResponse>
    {
        private readonly IHomeRepository _repository;
        public DeleteHomeCommandHandler(IHomeRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteHomeCommandResponse> Handle(DeleteHomeCommandRequest request, CancellationToken cancellationToken)
        {

            var home = await _repository.GetAsync(x => x.Id == request.Id);
            _repository.Remove(home);
            await _repository.CommitAsync();

            return new DeleteHomeCommandResponse
            {
                IsSuccess = true
            };
            throw new NotImplementedException();
        }
    }
}