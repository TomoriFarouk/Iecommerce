using System;
using AutoMapper;
using Ordering.Application.Command;
using Ordering.Application.Response;
using Ordering.Core.Entities;

namespace Ordering.Application.Mapper
{
	public class OrderingMapperProfile:Profile
	{
		public OrderingMapperProfile()
		{
			CreateMap<Customer, CustomerResponse>().ReverseMap();
			CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, EditCustomerCommand>().ReverseMap();
        }
	}
}

