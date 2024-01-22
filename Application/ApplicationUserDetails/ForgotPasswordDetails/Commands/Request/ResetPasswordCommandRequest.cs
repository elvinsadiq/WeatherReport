using Application.ForgotPasswordDetails.Commands.Response;
using MediatR;

namespace Application.ForgotPasswordDetails.Commands.Request
{
    public class ResetPasswordCommandRequest : IRequest<ResetPasswordCommandResponse>
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string RepeatNewPassword { get; set; }
    }
}