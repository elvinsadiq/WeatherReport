// DeleteCountryCommandHandler.cs
using Application.CheckoutDetails.CountryDetails.Commands.Request;
using Application.CheckoutDetails.CountryDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CheckoutDetails.CountryDetails.Handlers.CommandHandlers
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommandRequest, DeleteCountryCommandResponse>
    {
        private readonly ICountryRepository _repository;

        public DeleteCountryCommandHandler(ICountryRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeleteCountryCommandResponse> Handle(DeleteCountryCommandRequest request, CancellationToken cancellationToken)
        {
            var country = await _repository.GetAsync(x => x.Id == request.Id);

            if (country != null)
            {
                _repository.Remove(country);
                await _repository.CommitAsync();

                return new DeleteCountryCommandResponse
                {
                    IsSuccess = true
                };
            }

            return new DeleteCountryCommandResponse
            {
                IsSuccess = false
            };
        }
    }
}
