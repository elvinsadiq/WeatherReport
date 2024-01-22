using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.ApplicationUserDetails.Commands.Response;
using Application.ApplicationUserDetails.Commands.Request;
using Application.ApplicationUserDetails.Queries.Request;
using Application.ApplicationUserDetails.Queries.Response;
using Microsoft.AspNetCore.Authorization;

namespace Furniro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUser")]
        //[Authorize(Roles = "Admin,AppUser")]
        public async Task<ActionResult<CreateAppUserCommandResponse>> CreateUser(CreateAppUserCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            if (response.IsSuccess)
            {
                return Ok(new
                {
                    response.IsSuccess
                });
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        [HttpPut("DeleteUser")]
        [Authorize(Roles = "AppUser, Admin")]
        public async Task<ActionResult<SoftDeleteAppUserCommandResponse>> SoftDeleteUser(SoftDeleteAppUserCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            if (response.IsSuccess)
            {
                return Ok(new
                {
                    response.IsSuccess,
                    response.Message
                });
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        [HttpPut("ChangePassword")]
        [Authorize(Roles = "AppUser, Admin")]
        public async Task<ActionResult<ChangePasswordCommandResponse>> ChangePassword(ChangePasswordCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            if (response.IsSuccess)
            {
                return Ok(new
                {
                    response.IsSuccess,
                    response.Message
                });
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        [HttpPut("UpdateUser")]
        [Authorize(Roles = "AppUser, Admin")]
        public async Task<IActionResult> UpdateUser(UpdateAppUserCommandRequest requestModel)
        {
            try
            {
                var response = await _mediator.Send(requestModel);
                return Ok(response.IsSuccess);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }



        [HttpPost("Login")]
        public async Task<ActionResult<LoginAppUserCommandResponse>> Login(LoginAppUserCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            if (response.IsSuccess)
            {
                return Ok(
                    new
                    {
                        response.IsSuccess,
                        response.JwtToken,
                        response.RefreshToken,
                        response.UserId
                    }
                    );
            }
            else
            {
                throw new Exception(response.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetByIdAppUserQueryResponse>> GetUserById(int id)
        {
            var requestModel = new GetByIdAppUserQueryRequest { Id = id };
            var user = await _mediator.Send(requestModel);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}

