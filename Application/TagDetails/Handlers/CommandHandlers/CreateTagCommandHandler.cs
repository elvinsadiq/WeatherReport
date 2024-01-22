using Application.TagDetails.Commands.Request;
using Application.TagDetails.Commands.Response;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using AutoMapper;
using Domain.IRepositories;
using Application.SizeDetails.Commands.Request;
using Application.SizeDetails.Commands.Response;

namespace Application.TagDetails.Handlers.CommandHandlers
{
    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommandRequest, CreateTagCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;

        public CreateTagCommandHandler(IMapper mapper, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<CreateTagCommandResponse> Handle(CreateTagCommandRequest request, CancellationToken cancellationToken)
        {

            if (await _tagRepository.IsExistAsync(x => x.TagName == request.TagName))
            {
                return new CreateTagCommandResponse
                {
                    IsSuccess = false
                };
            }

            var tag = _mapper.Map<Tag>(request);

            await _tagRepository.AddAsync(tag);
            await _tagRepository.CommitAsync();

            return new CreateTagCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
