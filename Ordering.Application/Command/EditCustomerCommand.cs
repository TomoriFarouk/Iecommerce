﻿using System;
using MediatR;
using Ordering.Application.Response;

namespace Ordering.Application.Command
{
	public class EditCustomerCommand:IRequest<CustomerResponse>
	{
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

      
	}
}

