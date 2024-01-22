using Application.CategoryDetails.Commands.Request;
using Application.CategoryDetails.Commands.Response;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.CategoryDetails.Handlers.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            
            var categoryToDelete = await _categoryRepository.GetAsync(x => x.Id == request.Id);

            if (categoryToDelete == null)
            {
                return new DeleteCategoryCommandResponse
                {
                    IsSuccess = false
                };
            }
            
            _categoryRepository.Remove(categoryToDelete);
            await _categoryRepository.CommitAsync();

            return new DeleteCategoryCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
