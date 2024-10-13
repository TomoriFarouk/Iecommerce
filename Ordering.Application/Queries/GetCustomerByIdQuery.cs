using System;
using MediatR;
using Ordering.Core.Entities;

namespace Ordering.Application.Queries
{
	public class GetCustomerByIdQuery:IRequest<Customer>
	{
		public Int64 Id { get; set; }
		public GetCustomerByIdQuery(Int64 id)
		{
			this.Id = id;
		}
	}
}

