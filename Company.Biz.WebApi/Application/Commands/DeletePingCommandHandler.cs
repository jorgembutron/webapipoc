using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Commands
{
    public class DeletePingCommandHandler : IRequestHandler<DeletePingCommand, Response>
    {
        private readonly IPingRepository _repository;

        public DeletePingCommandHandler(IPingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(DeletePingCommand request, CancellationToken cancellationToken)
        {
            Ping ping = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (ping == null)
                return new Response(Result.NotFound);

            await _repository.DeleteAsync(ping, cancellationToken).ConfigureAwait(false);

            return new Response(Result.Ok);
        }
    }
}
