using System;
namespace Ordering.Application.Common.Interface
{
	public interface ITokenGenerator
	{
        public string GenerateJWTToken((string userId, string userName, IList<string> roles) userDetails);
    }
}

