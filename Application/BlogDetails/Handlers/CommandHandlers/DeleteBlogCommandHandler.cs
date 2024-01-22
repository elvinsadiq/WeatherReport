using Application.BlogDetails.Commands.Request;
using Application.BlogDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;

namespace Application.BlogDetails.Handlers.CommandHandlers
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommandRequest, DeleteBlogCommandResponse>
    {
        private readonly IBlogRepository _repository;
        public DeleteBlogCommandHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteBlogCommandResponse> Handle(DeleteBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetAsync(x => x.Id == request.Id);
            _repository.Remove(blog);
            await _repository.CommitAsync();

            return new DeleteBlogCommandResponse
            {
                IsSuccess = true,
                Message = "Blog deleted successfully"
            };
        }
    }
}