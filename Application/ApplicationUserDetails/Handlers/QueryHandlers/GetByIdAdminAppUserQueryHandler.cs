using Application.ApplicationUserDetails.Queries.Request;
using Application.ApplicationUserDetails.Queries.Response;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UserDetails.Handlers.QueryHandlers
{
    public class GetByIdAdminUserQueryHandler : IRequestHandler<GetByIdAdminUserQueryRequest, GetByIdAdminUserQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetByIdAdminUserQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetByIdAdminUserQueryResponse> Handle(GetByIdAdminUserQueryRequest request, CancellationToken cancellationToken)
        {
            if (_context != null)
            {
                var user = await _context.AppUsers.FirstOrDefaultAsync(p => p.Id == request.Id);

                if (user != null)
                {
                    var response = _mapper.Map<GetByIdAdminUserQueryResponse>(user);
                    return response;
                }
            }

            return new GetByIdAdminUserQueryResponse();
        }
    }
}
