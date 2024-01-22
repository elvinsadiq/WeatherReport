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
    public class UpdateSizeCommandHandler : IRequestHandler<UpdateSizeCommandRequest, UpdateSizeCommandResponse>
    {
       
        private readonly ISizeRepository _sizeRepository;

        public UpdateSizeCommandHandler(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<UpdateSizeCommandResponse> Handle(UpdateSizeCommandRequest request, CancellationToken cancellationToken)
        {

            var sizeToUpdate = await _sizeRepository.GetAsync(x => x.Id == request.Id);

            if (sizeToUpdate == null)
            {
                return new UpdateSizeCommandResponse
                {
                    IsSuccess = false
                };
            }

            if (await _sizeRepository.IsExistAsync(x => x.Id != request.Id && x.SizeName == request.SizeName))
            {
                return new UpdateSizeCommandResponse
                {
                    IsSuccess = false
                };
            }

            sizeToUpdate.SetDetail(request.SizeName);
            await _sizeRepository.UpdateAsync(sizeToUpdate);

            return new UpdateSizeCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
