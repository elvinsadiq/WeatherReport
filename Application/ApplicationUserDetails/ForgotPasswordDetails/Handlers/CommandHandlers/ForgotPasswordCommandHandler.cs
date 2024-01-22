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
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommandRequest, ForgotPasswordCommandResponse>
    {
        private readonly IAppUserRepository _repository;

        public ForgotPasswordCommandHandler(IAppUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ForgotPasswordCommandResponse> Handle(ForgotPasswordCommandRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _repository.FirstOrDefaultAsync(p => p.Email == request.Email);

            if (user != null)
            {
                string otpToken = (RandomGenerator.NextInt() % 1000000).ToString("000000");

                user.OTPToken = InputHasher.HashInputSHA256(otpToken);
                user.OTPTokenCreated = DateTime.Now.ToUniversalTime();
                user.OTPTokenExpires = DateTime.Now.AddMinutes(20).ToUniversalTime();

                await _repository.CommitAsync();

                SendOtpCodeToEmail(request.Email, otpToken);


                return new ForgotPasswordCommandResponse
                {
                    IsSuccess = true,
                    Message = "Security code sent to email"
                };
            }

            return new ForgotPasswordCommandResponse
            {
                IsSuccess = false,
                Message = "User with this email address doens't exist"
            };
        }

        private void SendOtpCodeToEmail(string receiverEmailAddress, string otpToken)
        {
            string fromMail = "elvindunyamektebi@gmail.com";
            string fromPassword = "vlydykfeavdeyqee";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = "Forgot Password";
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

                        p {
                            color: #666;
                            line-height: 1.6;
                        }

                        .otp-token {
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
                                                        <h1>Forgot Password</h1>
                                                        <p>Dear user, </p>
                                                        <p>We received a request to reset your password. Please use the following OTP code to reset your password:</p>
                                                        <p class=""otp-token"">" + otpToken + @"</p>
                                                        <p>If you did not initiate this request or have any concerns, please ignore this message.</p>
                                                        <p>If you have any questions or need assistance, please don't hesitate to contact our support team at <a href=""mailto:rnet102sql@gmail.com"">[Support Email]</a>.</p>
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

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            smtpClient.Send(message);
        }
    }
}

public static class RandomGenerator
{
    private static readonly ThreadLocal<System.Security.Cryptography.RandomNumberGenerator> crng = new ThreadLocal<System.Security.Cryptography.RandomNumberGenerator>(System.Security.Cryptography.RandomNumberGenerator.Create);
    private static readonly ThreadLocal<byte[]> bytes = new ThreadLocal<byte[]>(() => new byte[sizeof(int)]);
    public static int NextInt()
    {
        crng.Value.GetBytes(bytes.Value);
        return BitConverter.ToInt32(bytes.Value, 0) & int.MaxValue;
    }
    public static double NextDouble()
    {
        while (true)
        {
            long x = NextInt() & 0x001FFFFF;
            x <<= 31;
            x |= (long)NextInt();
            double n = x;
            const double d = 1L << 52;
            double q = n / d;
            if (q != 1.0)
                return q;
        }
    }
}