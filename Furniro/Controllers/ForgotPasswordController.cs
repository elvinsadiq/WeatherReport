using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.ApplicationUserDetails.Commands.Response;
using Application.ApplicationUserDetails.Commands.Request;
using Application.ForgotPasswordDetails.Commands.Response;
using Application.ForgotPasswordDetails.Commands.Request;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForgotPasswordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("SendOTPEmail")]
        //[Authorize(Roles = "Admin,AppUser")]
        public async Task<ActionResult<ForgotPasswordCommandResponse>> SendOTPEmail(ForgotPasswordCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        [HttpPost("OtpConfirmation")]
        //[Authorize(Roles = "Admin,AppUser")]
        public async Task<ActionResult<OtpConfirmationCommandResponse>> OtpConfirmation(OtpConfirmationCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        [HttpPost("ResetPassword")]
        //[Authorize(Roles = "Admin,AppUser")]
        public async Task<ActionResult<ResetPasswordCommandResponse>> ResetPassword(ResetPasswordCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            if (response.IsSuccess)
            {
                return Ok(response.Message);
            }
            else
            {
                throw new Exception(response.Message);
            }
        }
    }
}

