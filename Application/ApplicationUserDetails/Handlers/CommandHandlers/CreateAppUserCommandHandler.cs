using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Commands.Response;
using Application.Common.Interfaces;
using AutoMapper;
using Core.Helpers;
using Domain.Entities;
using MediatR;

namespace Application.ApplicationUserDetails.Handlers.CommandHandlers
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommandRequest, CreateAppUserCommandResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateAppUserCommandHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<CreateAppUserCommandResponse> Handle(CreateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            var appUser = _mapper.Map<AppUser>(request);
            ValidationChecker.ValidateUserName(request.UserName);

            if (_context.AppUsers.Any(u => u.UserName == request.UserName))
            {
                return new CreateAppUserCommandResponse
                {
                    IsSuccess = false,
                    Message = $"An account with username \"{request.UserName}\" already exists, Please use different username."
                };
            }

            ValidationChecker.ValidateUserEmailAddress(request.Email);

            if (_context.AppUsers.Any(u => u.Email == request.Email))
            {
                return new CreateAppUserCommandResponse
                {
                    IsSuccess = false,
                    Message = $"An account with email address \"{request.Email}\" already exists, Please login using this email address or reset the password."
                };
            }

            ValidationChecker.ValidateUserPassword(request.Password);

            appUser.Password = InputHasher.HashInputSHA256(request.Password);
            appUser.IsActive = true;
            appUser.RoleId = 2;

            await _context.AppUsers.AddAsync(appUser);

            await _context.SaveChangesAsync(cancellationToken);

            return new CreateAppUserCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
