using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.WebApi.Application.Commands;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Validations
{
    public class CreatePingCommandValidator : AbstractValidator<CreatePingCommand>
    {
        private readonly IPingRepository _repository;

        public async Task<bool> BeUniqueAsync(string bar, CancellationToken cancellationToken) =>
            !await _repository.CheckByNameAsync(bar).ConfigureAwait(false);

        public CreatePingCommandValidator(IPingRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("{PropertyName} no debe estar vacio")
                .MustAsync(BeUniqueAsync).WithMessage("{PropertyName} debe ser unico!")
                .MinimumLength(4).WithMessage("{PropertyName} tiene una longitud menor a 4 caracteres")
                .MaximumLength(20).WithMessage("{PropertyName} tiene una longitud mayor a 20 caracteres");
        }
    }
}
