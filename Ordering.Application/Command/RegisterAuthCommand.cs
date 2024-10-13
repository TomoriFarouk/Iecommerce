﻿using System;
using MediatR;
using Ordering.Application.Response;

namespace Ordering.Application.Command
{
	public class RegisterAuthCommand :IRequest<AuthResponse>
	{
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}

