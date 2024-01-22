using Application.ColorDetails.Queries.Request;
using Application.ColorDetails.Queries.Response;
using AutoMapper;
using Domain.IRepositories;
using MediatR;

namespace Application.ColorDetails.Handlers.QueryHandlers
{
    public class GetAllColorQueryHandler : IRequestHandler<GetAllColorQueryRequest, List<GetAllColorQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;

        public GetAllColorQueryHandler(IMapper mapper, IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<List<GetAllColorQueryResponse>> Handle(GetAllColorQueryRequest request, CancellationToken cancellationToken)
        {
            var colors = _colorRepository.GetAll(x => true);
            var response = _mapper.Map<List<GetAllColorQueryResponse>>(colors);

            return response;
        }
    }
}
