using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Commands
{
    public class EditPingCommandHandler : IRequestHandler<EditPingCommand, Response>
    {
        private readonly IPingRepository _repository;

        public EditPingCommandHandler(IPingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(EditPingCommand request, CancellationToken cancellationToken)
        {
            Ping ping = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (ping == null)
                return new Response(Result.NotFound);

            ping.Name = request.Name;

            await _repository.EditAsync(ping, cancellationToken).ConfigureAwait(false);

            return new Response(Result.Ok);
        }
    }
}
