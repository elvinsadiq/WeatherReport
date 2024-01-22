using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Commands.Response;
using Domain.IRepositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Application.ApplicationUserDetails.Handlers.CommandHandlers
{
    public class SendMailHandler : IRequestHandler<SendMailRequest, SendMailResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IAppUserRepository _appUserRepository;
        public SendMailHandler(IConfiguration configuration, IAppUserRepository appUserRepository)
        {
            _configuration = configuration;
            _appUserRepository = appUserRepository;
        }
        public async Task<SendMailResponse> Handle(SendMailRequest request, CancellationToken cancellationToken)
        {
            var user = _appUserRepository.Get(p => p.Email == request.ToEmail);
            if (user != null)
            {
                if (user.IsActive == false)
                {
                    await SendEmailAsync(request.ToEmail, user.UserName, cancellationToken);
                    return new SendMailResponse
                    {
                        IsEmailSent = true,
                        Message = "Your login session ended"
                    };
                }
                else
                {
                    return new SendMailResponse
                    {
                        IsEmailSent = false,
                        Message = "Your login session continued"
                    };
                }
            }
            return new SendMailResponse
            {
                IsEmailSent = false,
                Message = "user doesnt exist"
            };
        }
        private async Task SendEmailAsync(string receiverEmailAddress, string userName, CancellationToken cancellationToken)
        {
            string fromMail = "elvindunyamektebi@gmail.com";
            string fromPassword = "vlydykfeavdeyqee";
            MailMessage message = new()
            {
                Subject = "Info about ",
                From = new MailAddress(_configuration["Mail:Username"])
            };
            message.To.Add(new MailAddress(receiverEmailAddress));
            #region Custom HTML template
            message.Body = @"<!DOCTYPE html>
                <html>
                <head>
                    <style>
                        body {
                            font-family: Arial, sans-serif;
                            background-color: #f2f2f2;
                            margin: 0;
                            padding: 0;
                        }

                        table {
                            border-collapse: collapse;
                            width: 100%;
                        }

                        td {
                            padding: 20px;
                        }

                        h1 {
                            color: #333;
                        }
.deartext {
color:black;
 font-size: 24px;
                            font-weight: bold;
}
                        p {
                            color: #666;
                            line-height: 1.6;
                        }

                        .app-user {
                            font-size: 24px;
                            font-weight: bold;
                            color: #007bff; /* You can choose your desired color */
                        }
                    </style>
                </head>
                <body>
                    <table width=""100%"" bgcolor=""#f2f2f2"">
                        <tr>
                            <td align=""center"">
                                <table width=""600"" cellpadding=""0"" cellspacing=""0"" style=""background-color: #ffffff; border: 1px solid #e0e0e0;"">
                                    <tr>
                                        <td>
                                            <table width=""100%"">
                                                <tr>
                                                    <td align=""center"" style=""padding: 20px;"">
                                                        <h1>Account Blocked</h1>
        <span class=""deartext""><i>Dear</i></span>
        <span class=""app-user"">" + userName + @"</span>
        <p>We noticed that there were three unsuccessful attempts to log in to your account with incorrect passwords. For security reasons, your account has been blocked.</p>
        <p>Your account will be automatically unblocked after 1 hour.</p>
        <p>If you believe this is an error or need further assistance, please contact our support team.</p>
        <p>Thank you for your understanding.</p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </body>
                </html>";
            #endregion
            message.IsBodyHtml = true;
            var smtpClient = new SmtpClient()
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
                Host = _configuration["Mail:Host"]
            };
            await smtpClient.SendMailAsync(message, cancellationToken: cancellationToken);
        }
    }
}