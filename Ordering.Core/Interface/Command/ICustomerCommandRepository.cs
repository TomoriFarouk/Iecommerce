using System;
using Ordering.Core.Entities;
using Ordering.Core.Interface.Command.Base;

namespace Ordering.Core.Interface.Command
{
	public interface ICustomerCommandRepository: ICommandRepository<Customer>
	{
		
	}
}

