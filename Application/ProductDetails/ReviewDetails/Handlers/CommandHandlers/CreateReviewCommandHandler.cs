using Application.ReviewDetails.Commands.Request;
using Application.ReviewDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;

namespace Application.ReviewDetails.Handlers.CommandHandlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, CreateReviewCommandResponse>
    {
        private readonly IReviewRepository _repository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateReviewCommandResponse> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            var review = _mapper.Map<Review>(request);

            if(request.Rate <= 5 && request.Rate >= 1)
            {
                await _repository.AddAsync(review);
                await _repository.CommitAsync();

                return new CreateReviewCommandResponse
                {
                    IsSuccess = true
                };
            }

            return new CreateReviewCommandResponse
            {
                IsSuccess = false
            };
        }
    }
}