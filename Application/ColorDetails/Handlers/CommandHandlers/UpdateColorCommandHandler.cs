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
    public class UpdateColorCommandHandler : IRequestHandler<UpdateColorCommandRequest, UpdateColorCommandResponse>
    {
        private readonly IColorRepository _colorRepository;

        public UpdateColorCommandHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<UpdateColorCommandResponse> Handle(UpdateColorCommandRequest request, CancellationToken cancellationToken)
        {

            var colorToUpdate = await _colorRepository.GetAsync(x => x.Id == request.Id);

            if (colorToUpdate == null)
            {
                return new UpdateColorCommandResponse
                {
                    IsSuccess = false
                };
            }

            if (await _colorRepository.IsExistAsync(x => x.Id != request.Id && x.ColorHexCode == request.ColorHexCode))
            {
                return new UpdateColorCommandResponse
                {
                    IsSuccess = false
                };
            }

            colorToUpdate.SetDetail(request.ColorHexCode);
            await _colorRepository.UpdateAsync(colorToUpdate);

            return new UpdateColorCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
