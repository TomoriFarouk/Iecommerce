using System;
using Ordering.Core.Entities;
using Ordering.Core.Interface.Query.Base;

namespace Ordering.Core.Interface.Query
{
	public interface ICustomerQueryRepository:IQueryRepository<Customer>
	{
		Task<IReadOnlyList<Customer>> GetAllAsync();
		Task<Customer> GetByIdAsync(Int64 id);
		Task<Customer> GetCustomerByEmail(string email);
	}
}

