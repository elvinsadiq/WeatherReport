using Application.ForgotPasswordDetails.Commands.Request;
using Application.ForgotPasswordDetails.Commands.Response;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Core.Helpers;

namespace Application.ForgotPasswordDetails.Handlers.CommandHandlers
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommandRequest, ResetPasswordCommandResponse>
    {
        private readonly IAppUserRepository _repository;

        public ResetPasswordCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResetPasswordCommandResponse> Handle(ResetPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _repository.FirstOrDefaultAsync(p => p.Email == request.Email);

            ValidationChecker.ValidateUserPassword(request.NewPassword);

            if (user != null)
            {
                if (request.NewPassword != request.RepeatNewPassword)
                {
                    return new ResetPasswordCommandResponse
                    {
                        IsSuccess = false,
                        Message = "Passwords doesn't match"
                    };
                }
                else
                {
                    user.Password = InputHasher.HashInputSHA256(request.NewPassword);

                    await _repository.UpdateAsync(user);
                    await _repository.CommitAsync();

                    return new ResetPasswordCommandResponse
                    {
                        IsSuccess = true,
                        Message = "Password reset successful"
                    };
                }
            }

            return new ResetPasswordCommandResponse
            {
                IsSuccess = false,
                Message = "Password reset failed"
            };
        }
        
    }
}