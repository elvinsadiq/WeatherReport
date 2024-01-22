using Application.CategoryDetails.Commands.Request;
using Application.CategoryDetails.Commands.Response;
using Application.ColorDetails.Commands.Request;
using Application.ColorDetails.Commands.Response;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;

namespace Application.ColorDetails.Handlers.CommandHandlers
{
    public class CreateColorCommandHandler : IRequestHandler<CreateColorCommandRequest, CreateColorCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;

        public CreateColorCommandHandler(IMapper mapper, IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<CreateColorCommandResponse> Handle(CreateColorCommandRequest request, CancellationToken cancellationToken)
        {

            if (await _colorRepository.IsExistAsync(x => x.ColorHexCode == request.ColorHexCode))
            {
                return new CreateColorCommandResponse
                {
                    IsSuccess = false
                };
            }

            var color = _mapper.Map<Color>(request);

            await _colorRepository.AddAsync(color);
            await _colorRepository.CommitAsync();

            return new CreateColorCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
