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
    public class CreateHomeCommandHandler : IRequestHandler<CreateHomeCommandRequest, CreateHomeCommandResponse>
    {
        private readonly IHomeRepository _repository;
        private readonly IHostEnvironment _env;
        private readonly IMapper _mapper;
        public CreateHomeCommandHandler(IHomeRepository repository, IMapper mapper, IHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _env = env;
        }
        public async Task<CreateHomeCommandResponse> Handle(CreateHomeCommandRequest request, CancellationToken cancellationToken)
        {
            var home = _mapper.Map<CreateHomeCommandRequest, Home>(request);


            home.HomeImages = new List<HomeImage>();

            foreach (var image in request.Images)
            {
                string name = FileManager.Save(image, _env, "uploads/home/images");

                HomeImage homeImage = new HomeImage()
                {
                    ImageUrl = name
                };
                home.HomeImages.Add(homeImage);
            }
            await _repository.AddAsync(home);
            await _repository.CommitAsync();

            return new CreateHomeCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}