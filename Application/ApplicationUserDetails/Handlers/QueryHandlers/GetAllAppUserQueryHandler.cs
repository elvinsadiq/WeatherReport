using Application.ApplicationUserDetails.Queries.Request;
using Application.ApplicationUserDetails.Queries.Response;
using Application.CategoryDetails.Queries.Request;
using Application.CategoryDetails.Queries.Response;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ApplicationUserDetails.Handlers.QueryHandlers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllAppUserQueryRequest, List<GetAllAppUserQueryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetAllUserQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<GetAllAppUserQueryResponse>> Handle(GetAllAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            if (_context.AppUsers != null)
            {
                var users = await _context.AppUsers
                    .ProjectTo<GetAllAppUserQueryResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                return users;
            }

            return new List<GetAllAppUserQueryResponse>();
        }
    }
}
