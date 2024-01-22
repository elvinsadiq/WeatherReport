using Application.BlogDetails.Commands.Request;
using FluentValidation;

namespace Application.BlogDetails.Handlers.Validation
{
    public class BlogValidator : AbstractValidator<CreateBlogCommandRequest>
    {
        public BlogValidator()
        {
            RuleFor(c => c.Header).NotEmpty().NotNull();
            RuleFor(c => c.Text).NotEmpty().NotNull();
            RuleFor(c => c.CategoryId).NotEmpty().NotNull();
            RuleFor(c => c.AppUserId).NotEmpty().NotNull();
            RuleFor(c => c.Images).NotEmpty().NotNull();
        }
    }
}