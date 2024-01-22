using Application.ForgotPasswordDetails.Commands.Response;
using MediatR;

namespace Application.ForgotPasswordDetails.Commands.Request
{
    public class OtpConfirmationCommandRequest : IRequest<OtpConfirmationCommandResponse>
    {
        public string Email { get; set; }
        public string OtpToken { get; set; }
    }
}