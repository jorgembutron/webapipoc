using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.Infrastructure.Contexts;
using Company.Biz.WebApi.Application.Commands;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class EditPingCommandValidator : AbstractValidator<EditPingCommand>
    {
        private readonly IPingRepository _repository;
        private readonly DummyDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public EditPingCommandValidator(IPingRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("{PropertyName} no debe estar vacio")
                .MustAsync(BeUniqueAsync).WithMessage("{PropertyName} debe ser unico!")
                .MinimumLength(4).WithMessage("{PropertyName} tiene una longitud menor a 4 caracteres")
                .MaximumLength(20).WithMessage("{PropertyName} tiene una longitud mayor a 20 caracteres");
        }

        public async Task<bool> BeUniqueAsync(string bar, CancellationToken cancellationToken) =>
            await _repository.CheckByNameAsync(bar).ConfigureAwait(false);
    }
}
