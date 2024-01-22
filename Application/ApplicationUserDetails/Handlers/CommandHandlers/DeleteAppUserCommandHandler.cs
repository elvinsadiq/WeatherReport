﻿using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Commands.Response;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ApplicationUserDetails.Handlers.CommandHandlers
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommandRequest, DeleteAppUserCommandResponse>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAppUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteAppUserCommandResponse> Handle(DeleteAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteProduct = await _context.AppUsers.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (deleteProduct == null)
            {
                return new DeleteAppUserCommandResponse
                {
                    IsSuccess = false
                };
            }

            _context.AppUsers.Remove(deleteProduct);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteAppUserCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}
