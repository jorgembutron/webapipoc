using Company.Biz.Infrastructure.Contexts;
using Company.Biz.WebApi.Application.Commands;
using FluentValidation;

namespace Company.Biz.WebApi.Application.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class DeletePingCommandValidator : AbstractValidator<DeletePingCommand>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public DeletePingCommandValidator(DummyDbContext context)
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }
}
