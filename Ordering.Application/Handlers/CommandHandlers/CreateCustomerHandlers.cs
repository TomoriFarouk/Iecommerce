﻿using System;
using MediatR;
using Ordering.Application.Command;
using Ordering.Application.Mapper;
using Ordering.Application.Response;
using Ordering.Core.Entities;
using Ordering.Core.Interface.Command;

namespace Ordering.Application.Handlers.CommandHandlers
{
	
        public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
        {
            private readonly ICustomerCommandRepository _customerCommandRepository;
            public CreateCustomerHandler(ICustomerCommandRepository customerCommandRepository)
            {
                _customerCommandRepository = customerCommandRepository;
            }
            public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customerEntity = CustomerMapper.Mapper.Map<Customer>(request);

                if (customerEntity is null)
                {
                    throw new ApplicationException("There is a problem in mapper");
                }

                var newCustomer = await _customerCommandRepository.AddAsync(customerEntity);
                var customerResponse = CustomerMapper.Mapper.Map<CustomerResponse>(newCustomer);
                return customerResponse;
            }
        }
    
}

