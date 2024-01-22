﻿using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Commands.Response;
using Application.Common.Interfaces;
using Core.Helpers;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ApplicationUserDetails.Handlers.CommandHandlers
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommandRequest, ChangePasswordCommandResponse>
    {
        private readonly IApplicationDbContext _context;

        public ChangePasswordCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChangePasswordCommandResponse> Handle(ChangePasswordCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _context.AppUsers.FirstOrDefaultAsync(p => p.Id == request.Id);

            ValidationChecker.ValidateUserPassword(request.NewPassword);
            var currentPassword = InputHasher.HashInputSHA256(request.CurrentPassword);

            if (user.Password != currentPassword)
            {
                return new ChangePasswordCommandResponse
                {
                    IsSuccess = false,
                    Message = "Current password isn't correct"
                };
            }
            else if (request.NewPassword != request.RepeatNewPassword)
            {
                return new ChangePasswordCommandResponse
                {
                    IsSuccess = false,
                    Message = "Repeated password must be the same with new password"
                };
            }

            if (!string.IsNullOrEmpty(request.NewPassword))
            {
                user.Password = InputHasher.HashInputSHA256(request.NewPassword);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new ChangePasswordCommandResponse
            {
                IsSuccess = true,
                Message = "Password changed successfully"
            };
        }
    }
}
