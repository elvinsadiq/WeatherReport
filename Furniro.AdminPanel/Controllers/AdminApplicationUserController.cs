using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Application.ApplicationUserDetails.Queries.Response;
using Application.ApplicationUserDetails.Queries.Request;
using Application.ApplicationUserDetails.Commands.Response;
using Application.ApplicationUserDetails.Commands.Request;

namespace Furniro.AdminPanel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApplicationUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminApplicationUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<GetAllAppUserQueryResponse>>> GetAllUsers()
        {
            var requestModel = new GetAllAppUserQueryRequest();
            var allUsers = await _mediator.Send(requestModel);
            if (allUsers == null)
            {
                return NotFound();
            }
            return allUsers;
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = "Admin,AppUser")]
        public async Task<ActionResult<GetByIdAdminUserQueryResponse>> GetUserById(int id)
        {
            var requestModel = new GetByIdAdminUserQueryRequest { Id = id };
            var user = await _mediator.Send(requestModel);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost("CreateUser")]
        //[Authorize(Roles = "Admin,AppUser")]
        public async Task<ActionResult<CreateAppUserCommandResponse>> CreateUser(CreateAppUserCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            if (response.IsSuccess)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.Message); 

            }
        }

        [HttpPut]
        //[Authorize(Roles = "Admin,AppUser")]
        public async Task<IActionResult> UpdateUser(UpdateAppUserCommandRequest requestModel)
        {
            try
            {
                var response = await _mediator.Send(requestModel);
                if (response.IsSuccess)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                
            }
            return NoContent();
        }

        [HttpPut("ChangePassword")]
        //[Authorize(Roles = "Admin,AppUser")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommandRequest requestModel)
        {
            try
            {
                var response = await _mediator.Send(requestModel);
                if (response.IsSuccess)
                {
                    return Ok(response.Message);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
            catch (DbUpdateConcurrencyException)
            {

            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<DeleteAppUserCommandResponse>> DeleteUser(int id)
        {
            var requestModel = new DeleteAppUserCommandRequest { Id = id };
            var response = await _mediator.Send(requestModel);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginAppUserCommandResponse>> Login(LoginAppUserCommandRequest requestModel)
        {
            var response = await _mediator.Send(requestModel);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

