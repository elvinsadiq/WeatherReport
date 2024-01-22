using Application.CheckoutDetails.ProvinceDetails.Commands.Request;
using Application.CheckoutDetails.ProvinceDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;

namespace Application.CheckoutDetails.ProvinceDetails.Handlers.CommandHandler
{
    public class DeleteProvinceCommandHandler : IRequestHandler<DeleteProvinceCommandRequest, DeleteProvinceCommandResponse>
    {
        private readonly IProvinceRepository _repository;

        public DeleteProvinceCommandHandler(IProvinceRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteProvinceCommandResponse> Handle(DeleteProvinceCommandRequest request, CancellationToken cancellationToken)
        {
            var province = await _repository.GetAsync(x => x.Id == request.Id);

            if (province != null)
            {
                _repository.Remove(province);
                await _repository.CommitAsync();

                return new DeleteProvinceCommandResponse
                {
                    IsSuccess = true
                };
            }

            return new DeleteProvinceCommandResponse
            {
                IsSuccess = false
            };
        }
    }
}
