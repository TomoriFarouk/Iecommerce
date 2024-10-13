using System;
using MediatR;

namespace Ordering.Application.Command
{
	public class DeleteCustomerCommand : IRequest<String>
    {
		public Int64 Id { get; set; }

		public DeleteCustomerCommand(Int64 Id)
		{
			this.Id = Id;
		}
	}
}

