using Application.CheckoutDetails.Queries.Response;
using MediatR;
using System.Collections.Generic;

namespace Application.CheckoutDetails.Queries.Request
{
    public class GetAllOrderQueryRequest : IRequest<List<GetAllOrderQueryResponse>>
    {
    }
}