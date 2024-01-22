using Application.TagDetails.Queries.Request;
using Application.TagDetails.Queries.Response;
using Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using Domain.IRepositories;
using Application.SizeDetails.Queries.Request;
using Application.SizeDetails.Queries.Response;
using Domain.Entities;

namespace Application.TagDetails.Handlers.QueryHandlers
{
    public class GetByIdTagQueryHandler : IRequestHandler<GetByIdTagQueryRequest, GetByIdTagQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;

        public GetByIdTagQueryHandler(IMapper mapper, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }

        public async Task<GetByIdTagQueryResponse> Handle(GetByIdTagQueryRequest request, CancellationToken cancellationToken)
        {
            Tag tag = await _tagRepository.GetAsync(x => x.Id == request.Id);
            if (tag == null)
                return null;

            GetByIdTagQueryResponse getByIdTagResponse = _mapper.Map<GetByIdTagQueryResponse>(tag);
            return getByIdTagResponse;
        }
    }
}
