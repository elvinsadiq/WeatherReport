using Application.ProductDescriptionDetails.Queries.Request;
using Application.ProductDescriptionDetails.Queries.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductDescriptionDetails.Handlers
{
    public class GetByIdProductDescriptionQueryHandler : IRequestHandler<GetByIdProductDescriptionQueryRequest, GetByIdProductDescriptionQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDescriptionRepository _descriptionRepository;

        public GetByIdProductDescriptionQueryHandler(IMapper mapper, IDescriptionRepository descriptionRepository)
        {
            _mapper = mapper;
            _descriptionRepository = descriptionRepository;
        }
        public async Task<GetByIdProductDescriptionQueryResponse> Handle(GetByIdProductDescriptionQueryRequest request, CancellationToken cancellationToken)
        {
            Description description = await _descriptionRepository.GetAsync(x => x.Product.Id == request.Id, "DescriptionImages", "Product");
            if (description == null)
                return null;

            GetByIdProductDescriptionQueryResponse getByIdProductDescriptionResponse = _mapper.Map<GetByIdProductDescriptionQueryResponse>(description);
          
            return getByIdProductDescriptionResponse;
        }
    }
}
