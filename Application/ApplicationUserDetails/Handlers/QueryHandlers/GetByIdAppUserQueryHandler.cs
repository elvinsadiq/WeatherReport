using Application.ApplicationUserDetails.Queries.Request;
using Application.ApplicationUserDetails.Queries.Response;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserDetails.Handlers.QueryHandlers
{
    public class GetByIdAppUserQueryHandler : IRequestHandler<GetByIdAppUserQueryRequest, GetByIdAppUserQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetByIdAppUserQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetByIdAppUserQueryResponse> Handle(GetByIdAppUserQueryRequest request, CancellationToken cancellationToken)
        {
            if (_context != null)
            {
                var user = await _context.AppUsers.FirstOrDefaultAsync(p => p.Id == request.Id);

                if (user != null)
                {
                    var response = _mapper.Map<GetByIdAppUserQueryResponse>(user);
                    return response;
                }
            }

            return new GetByIdAppUserQueryResponse();
        }
    }
}
