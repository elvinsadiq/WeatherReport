using Application.CategoryDetails.Commands.Response;
using MediatR;

namespace Application.CategoryDetails.Commands.Request
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
