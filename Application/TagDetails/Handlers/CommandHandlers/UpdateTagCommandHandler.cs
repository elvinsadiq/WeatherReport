using Application.TagDetails.Commands.Request;
using Application.TagDetails.Commands.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.TagDetails.Handlers.CommandHandlers
{
    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommandRequest, UpdateTagCommandResponse>
    {
        private readonly ITagRepository _tagRepository;

        public UpdateTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<UpdateTagCommandResponse> Handle(UpdateTagCommandRequest request, CancellationToken cancellationToken)
        {

            var tagToUpdate = await _tagRepository.GetAsync(x => x.Id == request.Id);

            if (tagToUpdate == null)
            {
                return new UpdateTagCommandResponse
                {
                    IsSuccess = false
                };
            }

            if (await _tagRepository.IsExistAsync(x => x.Id != request.Id && x.TagName == request.TagName))
            {
                return new UpdateTagCommandResponse
                {
                    IsSuccess = false
                };
            }

            tagToUpdate.SetDetail(request.TagName);
            await _tagRepository.UpdateAsync(tagToUpdate);

            return new UpdateTagCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
