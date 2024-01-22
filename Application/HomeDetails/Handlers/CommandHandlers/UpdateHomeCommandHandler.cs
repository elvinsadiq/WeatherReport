using Application.HomeDetails.Commands.Request;
using Application.HomeDetails.Commands.Response;
using AutoMapper;
using Core.Helpers;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace Application.HomeDetails.Handlers.CommandHandlers
{
    public class UpdateHomeCommandHandler : IRequestHandler<UpdateHomeCommandRequest, UpdateHomeCommandResponse>
    {
        private readonly IHomeRepository _repository;
        private readonly IHostEnvironment _env;
        private readonly IMapper _mapper;
        public UpdateHomeCommandHandler(IHomeRepository repository, IMapper mapper, IHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _env = env;
        }
        public async Task<UpdateHomeCommandResponse> Handle(UpdateHomeCommandRequest request, CancellationToken cancellationToken)
        {
            var home = await _repository.GetAsync(x => x.Id == request.Id, "HomeImages");
            _mapper.Map(request, home);
            if (request.Images != null && request.Images.Any())
            {
                foreach (var existingImage in home.HomeImages)
                {
                    FileManager.Delete(_env.ContentRootPath, "uploads/home/images", existingImage.ImageUrl);
                }

                home.HomeImages.Clear();

                foreach (var file in request.Images)
                {
                    string fileName = FileManager.Save(file, _env, "uploads/home/images");
                    if (fileName != null)
                    {
                        var homeImage = new HomeImage
                        {
                            ImageUrl = fileName
                        };

                        home.HomeImages.Add(homeImage);
                    }
                    else
                    {
                        return new UpdateHomeCommandResponse
                        {
                            IsSuccess = false,
                        };
                    }

                }

            }
            await _repository.UpdateAsync(home);

            return new UpdateHomeCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}