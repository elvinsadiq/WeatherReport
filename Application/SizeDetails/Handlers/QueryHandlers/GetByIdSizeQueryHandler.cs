using Application.SizeDetails.Queries.Request;
using Application.SizeDetails.Queries.Response;
using Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Domain.IRepositories;
using Application.ColorDetails.Queries.Request;
using Application.ColorDetails.Queries.Response;
using Domain.Entities;

namespace Application.SizeDetails.Handlers.QueryHandlers
{
    public class GetByIdSizeQueryHandler : IRequestHandler<GetByIdSizeQueryRequest, GetByIdSizeQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;

        public GetByIdSizeQueryHandler(IMapper mapper, ISizeRepository sizeRepository)
        {
            _mapper = mapper;
            _sizeRepository = sizeRepository;
        }

        public async Task<GetByIdSizeQueryResponse> Handle(GetByIdSizeQueryRequest request, CancellationToken cancellationToken)
        {
            Size size = await _sizeRepository.GetAsync(x => x.Id == request.Id);
            if (size == null)
                return null;

            GetByIdSizeQueryResponse getByIdSizeResponse = _mapper.Map<GetByIdSizeQueryResponse>(size);
            return getByIdSizeResponse;
        }
    }
}
