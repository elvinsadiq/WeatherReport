using Application.ForgotPasswordDetails.Commands.Request;
using Application.ForgotPasswordDetails.Commands.Response;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System.Net.Mail;
using System.Net;
using Core.Helpers;

namespace Application.ForgotPasswordDetails.Handlers.CommandHandlers
{
    public class OtpConfirmationCommandHandler : IRequestHandler<OtpConfirmationCommandRequest, OtpConfirmationCommandResponse>
    {
        private readonly IAppUserRepository _repository;

        public OtpConfirmationCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OtpConfirmationCommandResponse> Handle(OtpConfirmationCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _repository.FirstOrDefaultAsync(p => p.Email == request.Email);

            if (user != null)
            {
                if(user.OTPToken == InputHasher.HashInputSHA256(request.OtpToken))
                {
                    if (user.OTPTokenExpires >= DateTime.UtcNow)
                    {
                        return new OtpConfirmationCommandResponse
                        {
                            IsSuccess = true,
                            Message = "OTP confirmation successfull, redirecting"
                        };
                    }
                    else
                    {
                        return new OtpConfirmationCommandResponse
                        {
                            IsSuccess = false,
                            Message = "OTP expired"
                        };
                    }
                }
            }

            return new OtpConfirmationCommandResponse
            {
                IsSuccess = false,
                Message = "OTP confirmation failed"
            };
        }
        
    }
}