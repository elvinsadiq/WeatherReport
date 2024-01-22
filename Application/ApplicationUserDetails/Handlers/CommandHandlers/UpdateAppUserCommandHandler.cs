using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Commands.Response;
using Application.Common.Interfaces;
using AutoMapper;
using Core.Helpers;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ApplicationUserDetails.Handlers.CommandHandlers
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommandRequest, UpdateAppUserCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public UpdateAppUserCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<UpdateAppUserCommandResponse> Handle(UpdateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _context.AppUsers.FirstOrDefaultAsync(p => p.Id == request.Id);
            ValidationChecker.ValidateUserEmailAddress(request.Email);

            if (user != null)
            {
                _mapper.Map(request, user);

                await _context.SaveChangesAsync(cancellationToken);
            }

            return new UpdateAppUserCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
