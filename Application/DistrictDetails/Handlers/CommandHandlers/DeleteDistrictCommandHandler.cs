using Application.DistrictDetails.Commands.Request;
using Application.DistrictDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DistrictDetails.Handlers.CommandHandlers
{
    public class DeleteDistrictCommandHandler : IRequestHandler<DeleteDistrictCommandRequest, DeleteDistrictCommandResponse>
    {
        private readonly IDistrictRepository _repository;

        public DeleteDistrictCommandHandler(IDistrictRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteDistrictCommandResponse> Handle(DeleteDistrictCommandRequest request, CancellationToken cancellationToken)
        {
            var district = await _repository.GetAsync(x => x.Id == request.Id);

            if (district == null)
            {
                return new DeleteDistrictCommandResponse { IsSuccess = false };
            }

            _repository.Remove(district);
            await _repository.CommitAsync();

            return new DeleteDistrictCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}