using Application.CategoryDetails.Commands.Request;
using Application.CategoryDetails.Commands.Response;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;

namespace Application.CategoryDetails.Handlers.CommandHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            
            var categoryToUpdate = await _categoryRepository.GetAsync(x => x.Id == request.Id);

            if (await _categoryRepository.IsExistAsync(x => x.Id != request.Id && x.CategoryName == request.CategoryName))
            {
                return new UpdateCategoryCommandResponse
                {
                    IsSuccess = false
                };
            }
           
            categoryToUpdate.SetDetail(request.CategoryName);
            await _categoryRepository.UpdateAsync(categoryToUpdate);

            return new UpdateCategoryCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
