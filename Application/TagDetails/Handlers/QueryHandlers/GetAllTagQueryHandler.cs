using Application.TagDetails.Queries.Request;
using Application.TagDetails.Queries.Response;
using Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Domain.IRepositories;
using Application.SizeDetails.Queries.Request;
using Application.SizeDetails.Queries.Response;

namespace Application.TagDetails.Handlers.QueryHandlers
{
    public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQueryRequest, List<GetAllTagQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;

        public GetAllTagQueryHandler(IMapper mapper, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<List<GetAllTagQueryResponse>> Handle(GetAllTagQueryRequest request, CancellationToken cancellationToken)
        {
            var tags = _tagRepository.GetAll(x => true);
            var response = _mapper.Map<List<GetAllTagQueryResponse>>(tags);

            return response;
        }
    }
}
