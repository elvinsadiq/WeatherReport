using Application.SizeDetails.Queries.Request;
using Application.SizeDetails.Queries.Response;
using Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Domain.IRepositories;
using Application.ColorDetails.Queries.Request;
using Application.ColorDetails.Queries.Response;

namespace Application.SizeDetails.Handlers.QueryHandlers
{
    public class GetAllSizeQueryHandler : IRequestHandler<GetAllSizeQueryRequest, List<GetAllSizeQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;

        public GetAllSizeQueryHandler(IMapper mapper, ISizeRepository sizeRepository)
        {
            _mapper = mapper;
            _sizeRepository = sizeRepository;
        }

        public async Task<List<GetAllSizeQueryResponse>> Handle(GetAllSizeQueryRequest request, CancellationToken cancellationToken)
        {
            var query = _sizeRepository.GetAll(x => true);
            var response = _mapper.Map<List<GetAllSizeQueryResponse>>(query.Skip((request.Page - 1) * 5).Take(5));

            PaginationListDto<GetAllSizeQueryResponse> model =
                new PaginationListDto<GetAllSizeQueryResponse>(response, request.Page, 5, query.Count());

            return model.Items;
        }
    }
}
