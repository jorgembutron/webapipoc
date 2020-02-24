using Company.Biz.Infrastructure.Contexts;
using Company.Biz.WebApi.Application.Commands;
using FluentValidation;

namespace Company.Biz.WebApi.Application.Validations
{
    public class DeletePingCommandValidator : AbstractValidator<DeletePingCommand>
    {
        public DeletePingCommandValidator(DummyDbContext context)
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
