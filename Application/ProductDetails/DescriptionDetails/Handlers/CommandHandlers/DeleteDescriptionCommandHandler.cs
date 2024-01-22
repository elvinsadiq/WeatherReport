using Application.DescriptionDetails.Commands.Request;
using Application.DescriptionDetails.Commands.Response;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.DescriptionDetails.Handlers.CommandHandlers
{
    public class DeleteDescriptionCommandHandler : IRequestHandler<DeleteDescriptionCommandRequest, DeleteDescriptionCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDescriptionRepository _descriptionRepository;

        public DeleteDescriptionCommandHandler(IMapper mapper, IDescriptionRepository descriptionRepository)
        {
            _mapper = mapper;
            _descriptionRepository = descriptionRepository;
        }

        public async Task<DeleteDescriptionCommandResponse> Handle(DeleteDescriptionCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var descriptionToDelete = await _descriptionRepository.GetAsync(x => x.Id == request.Id);

                if (descriptionToDelete == null)
                {
                    return new DeleteDescriptionCommandResponse
                    {
                        IsSuccess = false,
                    };
                }

                _descriptionRepository.Remove(descriptionToDelete);
                await _descriptionRepository.CommitAsync();

                return new DeleteDescriptionCommandResponse
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                return new DeleteDescriptionCommandResponse
                {
                    IsSuccess = false,
                };
            }
        }
    }
}
