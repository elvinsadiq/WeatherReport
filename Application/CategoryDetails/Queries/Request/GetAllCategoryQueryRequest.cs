using Application.CategoryDetails.Queries.Response;
using MediatR;

namespace Application.CategoryDetails.Queries.Request
{
    public class GetAllCategoryQueryRequest : IRequest<List<GetAllCategoryQueryResponse>>
    {
    }
}
