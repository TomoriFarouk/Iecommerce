using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Command;
using System.Threading.Tasks;
using Ordering.Application.Response;

namespace Ordering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("Login")]
        [ProducesDefaultResponseType(typeof(AuthResponse))]
        public async Task<IActionResult> Login([FromBody] AuthCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("Register")]
        [ProducesDefaultResponseType(typeof(AuthResponse))]
        public async Task<IActionResult> Register([FromBody] RegisterAuthCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

