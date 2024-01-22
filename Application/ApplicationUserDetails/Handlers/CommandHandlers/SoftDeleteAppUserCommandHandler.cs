using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Commands.Response;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ApplicationUserDetails.Handlers.CommandHandlers
{
    public class SoftDeleteAppUserCommandHandler : IRequestHandler<SoftDeleteAppUserCommandRequest, SoftDeleteAppUserCommandResponse>
    {
        private readonly IApplicationDbContext _context;

        public SoftDeleteAppUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SoftDeleteAppUserCommandResponse> Handle(SoftDeleteAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            var appUser = await _context.AppUsers.FirstOrDefaultAsync(p => p.UserName == request.UserName);
            if (appUser == null)
            {
                return new SoftDeleteAppUserCommandResponse
                {
                    IsSuccess = false,
                    Message = "User not found"
                };
            }

            appUser.IsActive = false;

            await _context.SaveChangesAsync(cancellationToken);

            return new SoftDeleteAppUserCommandResponse
            {
                IsSuccess = true,
                Message = "User Deleted Successfully"
            };
        }
    }
}
