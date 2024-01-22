using Application.CategoryDetails.Queries.Request;
using Application.CategoryDetails.Queries.Response;
using Application.ColorDetails.Queries.Request;
using Application.ColorDetails.Queries.Response;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;

namespace Application.ColorDetails.Handlers.QueryHandlers
{
    public class GetByIdColorQueryHandler : IRequestHandler<GetByIdColorQueryRequest, GetByIdColorQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;

        public GetByIdColorQueryHandler(IMapper mapper, IColorRepository colorRepository)
        {
            _mapper = mapper;
            _colorRepository = colorRepository;
        }

        public async Task<GetByIdColorQueryResponse> Handle(GetByIdColorQueryRequest request, CancellationToken cancellationToken)
        {
            Color color = await _colorRepository.GetAsync(x => x.Id == request.Id);
            if (color == null)
                return null;

            GetByIdColorQueryResponse getByIdColorResponse = _mapper.Map<GetByIdColorQueryResponse>(color);
            return getByIdColorResponse;
        }
    }
}
