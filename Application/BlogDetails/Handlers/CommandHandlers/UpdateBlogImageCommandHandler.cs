using Application.BlogDetails.Commands.Request;
using Application.BlogDetails.Commands.Response;
using Core.Helpers;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace Application.BlogDetails.Handlers.CommandHandlers
{
    public class UpdateBlogImageCommandHandler : IRequestHandler<UpdateBlogImageCommandRequest, UpdateBlogCommandResponse>
    {
        private readonly IBlogRepository _repository;
        private readonly IHostEnvironment _env;
        public UpdateBlogImageCommandHandler(IBlogRepository repository, IHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }
        public async Task<UpdateBlogCommandResponse> Handle(UpdateBlogImageCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetAsync(x => x.Id == request.Id, "BlogImages");
            if (request.Images != null && request.Images.Any())
            {
                foreach (var existingImage in blog.BlogImages)
                {
                    FileManager.Delete(_env.ContentRootPath, "uploads/blogs", existingImage.ImageUrl);
                }
                blog.BlogImages.Clear();

                foreach (var file in request.Images)
                {
                    string fileName = FileManager.Save(file, _env, "uploads/blogs");
                    if (fileName != null)
                    {
                        var blogImage = new BlogImage
                        {
                            ImageUrl = fileName
                        };
                        blog.BlogImages.Add(blogImage);
                    }
                    else
                    {
                        return new UpdateBlogCommandResponse
                        {
                            IsSuccess = false,
                            Message = "Blog updated failed"
                        };
                    }
                }
            }
            await _repository.UpdateAsync(blog);
            await _repository.CommitAsync();

            return new UpdateBlogCommandResponse
            {
                IsSuccess = true,
                Message = "Blog updated successfully"
            };
        }
    }
}
