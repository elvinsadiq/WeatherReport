using Application.SizeDetails.Commands.Request;
using Application.SizeDetails.Commands.Response;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using AutoMapper;
using Domain.IRepositories;
using Application.ColorDetails.Commands.Request;
using Application.ColorDetails.Commands.Response;

namespace Application.SizeDetails.Handlers.CommandHandlers
{
    public class CreateSizeCommandHandler : IRequestHandler<CreateSizeCommandRequest, CreateSizeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;

        public CreateSizeCommandHandler(IMapper mapper, ISizeRepository sizeRepository)
        {
            _mapper = mapper;
            _sizeRepository = sizeRepository;
        }

        public async Task<CreateSizeCommandResponse> Handle(CreateSizeCommandRequest request, CancellationToken cancellationToken)
        {

            if (await _sizeRepository.IsExistAsync(x => x.SizeName == request.SizeName))
            {
                return new CreateSizeCommandResponse
                {
                    IsSuccess = false
                };
            }

            var size = _mapper.Map<Size>(request);

            await _sizeRepository.AddAsync(size);
            await _sizeRepository.CommitAsync();

            return new CreateSizeCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
