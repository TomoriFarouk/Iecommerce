using System;
using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Ordering.Infrastructure.Data
{
	public class DbConnector
	{
        private readonly IConfiguration _configuration;

        public DbConnector(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IDbConnection CreateConnection()
		{
			string _connectionString = _configuration.GetConnectionString("DefaultConnection");
			return new SqliteConnection(_connectionString);
		}
	}
}

