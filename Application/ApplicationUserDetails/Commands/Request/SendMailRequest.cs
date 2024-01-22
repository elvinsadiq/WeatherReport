using Application.ApplicationUserDetails.Commands.Response;
using MediatR;

namespace Application.ApplicationUserDetails.Commands.Request
{
    public class SendMailRequest : IRequest<SendMailResponse>
    {
        public string ToEmail { get; set; }
    }
}