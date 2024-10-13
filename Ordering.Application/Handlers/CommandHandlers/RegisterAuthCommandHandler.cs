using System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Ordering.Application.Command;
using Ordering.Application.Response;
using Ordering.Infrastructure.Data.Identity;

namespace Ordering.Application.Handlers.CommandHandlers
{
	public class RegisterAuthCommandHandler : IRequestHandler<RegisterAuthCommand, AuthResponse>
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;


        public RegisterAuthCommandHandler(UserManager<ApplicationUser> userManager,IMediator mediator)
        {
            _mediator = mediator;
            _userManager = userManager;

        }

        public async Task<AuthResponse> Handle(RegisterAuthCommand request, CancellationToken cancellationToken)
        {
            var userByEmail = await _userManager.FindByEmailAsync(request.Email);
            var userByUsername = await _userManager.FindByNameAsync(request.UserName);
            if (userByEmail is not null || userByUsername is not null)
            {
                throw new ArgumentException($"User with email {request.Email} or username {request.UserName} already exists.");
            }

            ApplicationUser user = new()
            {
                Email = request.Email,
                UserName = request.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new ArgumentException($"Unable to register user {request.UserName} ");
            }

          
            AuthCommand command = new()
            {
                UserName = user.UserName,
                Password = request.Password
            };
            return await _mediator.Send(command, cancellationToken);

          
        }
}
    }
