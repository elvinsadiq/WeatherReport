using Application.CategoryDetails.Queries.Request;
using Application.CategoryDetails.Queries.Response;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CategoryDetails.Handlers.QueryHandlers
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetByIdCategoryQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetAsync(x => x.Id == request.Id);
            if (category == null)
                return null;

            GetByIdCategoryQueryResponse getByIdCategoryResponse = _mapper.Map<GetByIdCategoryQueryResponse>(category);
            return getByIdCategoryResponse;
        }
    }
}
