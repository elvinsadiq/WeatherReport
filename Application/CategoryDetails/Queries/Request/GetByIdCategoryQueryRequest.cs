using Application.CategoryDetails.Queries.Response;
using MediatR;

namespace Application.CategoryDetails.Queries.Request
{
    public class GetByIdCategoryQueryRequest : IRequest<GetByIdCategoryQueryResponse>
    {
        public int Id { get; set; }
    }
}
