using System;
using MediatR;
using Ordering.Core.Entities;

namespace Ordering.Application.Queries
{
	public class GetAllCustomerQuery:IRequest<List<Customer>>
	{
		
	}
}

