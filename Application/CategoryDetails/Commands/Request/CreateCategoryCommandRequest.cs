using Application.CategoryDetails.Commands.Response;
using MediatR;

namespace Application.CategoryDetails.Commands.Request
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string CategoryName { get; set; }
    }
}
