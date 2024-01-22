using Application.CategoryDetails.Commands.Request;
using Application.CategoryDetails.Commands.Response;
using Application.ColorDetails.Commands.Request;
using Application.ColorDetails.Commands.Response;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.ColorDetails.Handlers.CommandHandlers
{
    public class DeleteColorCommandHandler : IRequestHandler<DeleteColorCommandRequest, DeleteColorCommandResponse>
    {
        private readonly IColorRepository _colorRepository;

        public DeleteColorCommandHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<DeleteColorCommandResponse> Handle(DeleteColorCommandRequest request, CancellationToken cancellationToken)
        {

            var colorToDelete = await _colorRepository.GetAsync(x => x.Id == request.Id);

            if (colorToDelete == null)
            {
                return new DeleteColorCommandResponse
                {
                    IsSuccess = false
                };
            }

            _colorRepository.Remove(colorToDelete);
            await _colorRepository.CommitAsync();

            return new DeleteColorCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
