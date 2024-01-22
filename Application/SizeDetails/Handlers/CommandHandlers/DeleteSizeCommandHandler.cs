using Application.SizeDetails.Commands.Request;
using Application.SizeDetails.Commands.Response;
using Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Domain.IRepositories;
using Application.ColorDetails.Commands.Request;
using Application.ColorDetails.Commands.Response;

namespace Application.SizeDetails.Handlers.CommandHandlers
{
    public class DeleteSizeCommandHandler : IRequestHandler<DeleteSizeCommandRequest, DeleteSizeCommandResponse>
    {
        private readonly ISizeRepository _sizeRepository;

        public DeleteSizeCommandHandler(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<DeleteSizeCommandResponse> Handle(DeleteSizeCommandRequest request, CancellationToken cancellationToken)
        {

            var sizeToDelete = await _sizeRepository.GetAsync(x => x.Id == request.Id);

            if (sizeToDelete == null)
            {
                return new DeleteSizeCommandResponse
                {
                    IsSuccess = false
                };
            }

            _sizeRepository.Remove(sizeToDelete);
            await _sizeRepository.CommitAsync();

            return new DeleteSizeCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
