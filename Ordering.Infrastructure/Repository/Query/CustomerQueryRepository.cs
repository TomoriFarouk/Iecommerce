using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Ordering.Core.Entities;
using Ordering.Core.Interface.Query;
using Ordering.Infrastructure.Repository.Query.Base;

namespace Ordering.Infrastructure.Repository.Query
{
	public class CustomerQueryRepository:QueryRepository<Customer> , ICustomerQueryRepository
	{
		public CustomerQueryRepository(IConfiguration configuration):base (configuration)
		{
		}

		public async Task<IReadOnlyList<Customer>> GetAllAsync()
		{
			try
			{
				var query = "SELECT * FROM CUSTOMERS";
				using(var connection = CreateConnection())
				{
					return (await connection.QueryAsync<Customer>(query)).ToList();
				}
			}
			catch(Exception exp)
			{
				throw new Exception(exp.Message, exp);
			}
		}

		public async Task<Customer> GetByIdAsync(long id)
		{
			try
			{
				var query = "SELECT * FROM CUSTOMER WHERE Id =@Id";
				var parameters = new DynamicParameters();
				parameters.Add("Id", id, System.Data.DbType.Int64);
				using(var connection = CreateConnection())
				{
					return (await connection.QueryFirstOrDefaultAsync<Customer>(query, parameters));
				}
			}
			catch (Exception exp)
			{
				throw new Exception(exp.Message, exp);
			}
		}

		public async Task<Customer> GetCustomerByEmail(string email)
		{
			try
			{
				var query = "SELECT * FROM CUSTOMER WHERE EMAIL=@email";
				var parameters = new DynamicParameters();
				parameters.Add("Email", email, System.Data.DbType.String);
				using(var connection = CreateConnection())
				{
					return (await connection.QueryFirstOrDefaultAsync<Customer>(query, parameters));
				}
			}
			catch(Exception exp)
			{
				throw new Exception(exp.Message, exp);
			}
		}
	}
}

