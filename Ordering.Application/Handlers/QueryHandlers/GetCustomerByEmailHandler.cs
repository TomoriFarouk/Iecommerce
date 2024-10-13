using System;
using MediatR;
using Ordering.Application.Queries;
using Ordering.Core.Entities;
using Ordering.Core.Interface.Query;

namespace Ordering.Application.Handlers.QueryHandlers
{
    public class GetCustomerByEmailHandler : IRequestHandler<GetCustomerByEmailQuery, Customer>
    {
        private readonly IMediator _mediator;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetCustomerByEmailHandler(IMediator mediator, ICustomerQueryRepository customerQueryRepository)
        {
            _mediator = mediator;
            _customerQueryRepository = customerQueryRepository;
        }
        public async Task<Customer> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new GetAllCustomerQuery());
            var selectedCustomer = customers.FirstOrDefault(x => x.Email.ToLower().Contains(request.Email.ToLower()));
            return selectedCustomer;

            //var customers = await _customerQueryRepository.GetCustomerByEmail(request.Email);
            //return customers;
        }
    }
}

