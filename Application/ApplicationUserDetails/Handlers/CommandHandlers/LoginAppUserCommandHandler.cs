using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Commands.Response;
using Application.Common.Interfaces;
using Core.Helpers;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.ApplicationUserDetails.Commands
{
    public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommandRequest, LoginAppUserCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IApplicationDbContext _context;
        private readonly ILoginFailureTrackerRepository _loginFailureTrackerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginAppUserCommandHandler(IApplicationDbContext context,
                                          IConfiguration configuration,
                                          IHttpContextAccessor httpContextAccessor,
                                          ILoginFailureTrackerRepository loginFailureTrackerRepository)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _loginFailureTrackerRepository = loginFailureTrackerRepository;
        }

        public async Task<LoginAppUserCommandResponse> Handle(LoginAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            // Hash the password provided in the login request
            var hashedPassword = InputHasher.HashInputSHA256(request.Password);

            
            // Retrieve the user from the database based on the provided username
            var appUser = await _context.AppUsers.Include(m => m.AppUserRole).FirstOrDefaultAsync(u => u.UserName == request.UserName);

            // Check credentials and if the user is Active
            if (appUser == null)
            {
                return new LoginAppUserCommandResponse { IsSuccess = false, Message = "Account with this username doesn't exist" };
            }
            else if (!appUser.IsActive)
            {
                return new LoginAppUserCommandResponse { IsSuccess = false, Message = "This user has been deleted" };
            }
            
            var loginFailureTracker = await _loginFailureTrackerRepository.FirstOrDefaultAsync(u => u.AppUserId == appUser.Id);

            if (loginFailureTracker != null)
            {
                if (loginFailureTracker.IsBlocked)
                {
                    if (loginFailureTracker.BlockLoginExpireTime > DateTime.UtcNow)
                    {
                        TimeSpan timeDifference = loginFailureTracker.BlockLoginExpireTime - DateTime.UtcNow;

                        // Display the time difference in hours, minutes, and seconds
                        return new LoginAppUserCommandResponse
                        {
                            IsSuccess = false,
                            Message = $"User has been blocked. Try again in: {timeDifference.Hours} hours, {timeDifference.Minutes} minutes, {timeDifference.Seconds} seconds"
                        };
                    }
                    else
                    {
                        loginFailureTracker.IsBlocked = false;
                        await _loginFailureTrackerRepository.UpdateAsync(loginFailureTracker);
                    }
                }
            }

            if (appUser.Password == hashedPassword)
            {
                var jwtToken = GenerateJwtToken(appUser);

                string refreshToken = await SetRefreshToken(appUser, cancellationToken);

                if (loginFailureTracker != null)
                {
                    _context.LoginFailureTracker.Remove(loginFailureTracker);
                    await _context.SaveChangesAsync(cancellationToken);
                }

                return new LoginAppUserCommandResponse
                {
                    IsSuccess = true,
                    JwtToken = jwtToken,
                    RefreshToken = refreshToken,
                    UserId = appUser.Id
                };
            }
            else if (appUser.Password != hashedPassword)
            {
                if (loginFailureTracker == null)
                {
                    loginFailureTracker = new LoginFailureTracker();
                    loginFailureTracker.SetDetails(appUser.Id, 1, false);
                    await _context.LoginFailureTracker.AddAsync(loginFailureTracker);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    if (loginFailureTracker.LoginTryCount < 3)
                    {
                        loginFailureTracker.IncreaseLoginTryCount();
                    }
                    else
                    {
                        loginFailureTracker.BlockUser();
                        await _loginFailureTrackerRepository.UpdateAsync(loginFailureTracker);
                        TimeSpan timeDifference = loginFailureTracker.BlockLoginExpireTime - DateTime.UtcNow;

                        // Display the time difference in hours, minutes, and seconds
                        return new LoginAppUserCommandResponse
                        {
                            IsSuccess = false,
                            Message = $"User has been blocked. Try again in: {timeDifference.Hours} hours, {timeDifference.Minutes} minutes, {timeDifference.Seconds} seconds"
                        };
                    }
                    await _loginFailureTrackerRepository.UpdateAsync(loginFailureTracker);
                }

                return new LoginAppUserCommandResponse
                {
                    Message = "Password Is Wrong"
                };
            }

            return new LoginAppUserCommandResponse { IsSuccess = false };
        }

        private string GenerateJwtToken(AppUser appUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value));

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim(ClaimTypes.Role, appUser.AppUserRole.RoleName.ToString())
            };
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var jwtToken = new JwtSecurityToken
            (
                    claims: claims,
                    expires: DateTime.Now.AddYears(1),
                    signingCredentials: creds
            );
            var jwt = tokenHandler.WriteToken(jwtToken);
            return jwt;
        }

        private async Task<string> SetRefreshToken(AppUser appUser, CancellationToken cancellationToken)
        {
            string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            DateTime refreshTokenExpireTime = DateTime.Now.AddDays(365).ToUniversalTime();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshTokenExpireTime
            };
            _httpContextAccessor?.HttpContext?.Response
                .Cookies.Append("refreshToken", refreshToken, cookieOptions);

            appUser.RefreshToken = refreshToken;
            //appUser.RefreshTokenCreated = DateTime.Now.ToUniversalTime();
            //appUser.RefreshTokenExpires = refreshTokenExpireTime;

            await _context.SaveChangesAsync(cancellationToken);

            return refreshToken;
        }
    }
}
