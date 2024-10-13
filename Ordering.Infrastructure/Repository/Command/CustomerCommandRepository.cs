using System;
using Ordering.Core.Entities;
using Ordering.Core.Interface.Command;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repository.Command.Base;

namespace Ordering.Infrastructure.Repository.Command
{
	public class CustomerCommandRepository :CommandRepository<Customer>, ICustomerCommandRepository
	{
		public CustomerCommandRepository(ApplicationDbContext context):base(context)
		{
		}
	}
}

