using Application.FavoriteDetails.Queries.Response;
using MediatR;

namespace Application.FavoriteDetails.Queries.Request
{
    public class GetFavoritesByUserIdQueryRequest : IRequest<List<GetFavoritesByUserIdQueryResponse>>
    {
        public int UserId { get; set; }
    }
}