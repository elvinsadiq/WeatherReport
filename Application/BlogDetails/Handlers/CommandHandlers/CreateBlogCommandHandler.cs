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
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommandRequest, CreateBlogCommandResponse>
    {
        private readonly IBlogRepository _repository;
        private readonly IHostEnvironment _env;
        private readonly IMapper _mapper;
        public CreateBlogCommandHandler(IBlogRepository repository, IMapper mapper, IHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _env = env;
        }
        public async Task<CreateBlogCommandResponse> Handle(CreateBlogCommandRequest request, CancellationToken cancellationToken)
        {
            var blog = _mapper.Map<CreateBlogCommandRequest, Blog>(request);
            blog.BlogImages = new List<BlogImage>();
            foreach (var image in request.Images)
            {
                string name = FileManager.Save(image, _env, "uploads/blogs");
                BlogImage blogImage = new()
                {
                    ImageUrl = name
                };
                blog.BlogImages.Add(blogImage);
            }
            await _repository.AddAsync(blog);
            await _repository.CommitAsync();

            return new CreateBlogCommandResponse
            {
                IsSuccess = true,
                Message = "Blog created successfully"
            };
        }
    }
}