using Application.TagDetails.Commands.Request;
using Application.TagDetails.Commands.Response;
using Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Domain.IRepositories;
using Application.SizeDetails.Commands.Request;
using Application.SizeDetails.Commands.Response;

namespace Application.TagDetails.Handlers.CommandHandlers
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommandRequest, DeleteTagCommandResponse>
    {
        private readonly ITagRepository _tagRepository;

        public DeleteTagCommandHandler(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<DeleteTagCommandResponse> Handle(DeleteTagCommandRequest request, CancellationToken cancellationToken)
        {

            var tagToDelete = await _tagRepository.GetAsync(x => x.Id == request.Id);

            if (tagToDelete == null)
            {
                return new DeleteTagCommandResponse
                {
                    IsSuccess = false
                };
            }

            _tagRepository.Remove(tagToDelete);
            await _tagRepository.CommitAsync();

            return new DeleteTagCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
