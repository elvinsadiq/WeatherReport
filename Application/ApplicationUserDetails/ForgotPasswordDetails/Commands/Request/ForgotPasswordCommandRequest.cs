using Application.ForgotPasswordDetails.Commands.Response;
using MediatR;

namespace Application.ForgotPasswordDetails.Commands.Request
{
    public class ForgotPasswordCommandRequest : IRequest<ForgotPasswordCommandResponse>
    {
        public string Email { get; set; }
    }
}