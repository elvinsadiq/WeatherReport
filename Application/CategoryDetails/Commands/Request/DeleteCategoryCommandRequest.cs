using Application.CategoryDetails.Commands.Response;
using MediatR;

namespace Application.CategoryDetails.Commands.Request
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
    {
        public int Id { get; set; }
    }
}
