using Application.BlogDetails.Commands.Request;
using Application.BlogDetails.Commands.Response;
using AutoMapper;
using Core.Helpers;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace Application.BlogDetails.Handlers.CommandHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommandRequest, UpdateBlogCommandResponse>
    {
        private readonly IBlogRepository _repository;
        private readonly IHostEnvironment _env;
        private readonly IMapper _mapper;
        public UpdateBlogCommandHandler(IBlogRepository repository, IMapper mapper, IHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _env = env;
        }
        public async Task<UpdateBlogCommandResponse> Handle(UpdateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetAsync(x => x.Id == request.Id, "BlogImages");
            _ = _mapper.Map(request, blog);
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