using System;
using MediatR;
using Ordering.Application.Queries;
using Ordering.Core.Entities;
using Ordering.Core.Interface.Query;

namespace Ordering.Application.Handlers.QueryHandlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly IMediator _mediator;
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetCustomerByIdHandler(IMediator mediator,ICustomerQueryRepository customerQueryRepository)
        {
            _mediator = mediator;
            _customerQueryRepository = customerQueryRepository;
        }
        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customers = await _mediator.Send(new GetAllCustomerQuery());
            var selectedCustomer = customers.FirstOrDefault(x => x.Id == request.Id);
            return selectedCustomer;

            //var customers = await _customerQueryRepository.GetByIdAsync(request.Id);
            //return customers;
        }
    }
}

