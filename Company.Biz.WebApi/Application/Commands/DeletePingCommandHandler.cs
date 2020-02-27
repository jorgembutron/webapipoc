using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.WebApi.Exceptions;
using Company.Biz.WebApi.Resources;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeletePingCommandHandler : IRequestHandler<DeletePingCommand, bool>
    {
        private readonly IPingRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public DeletePingCommandHandler(IPingRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeletePingCommand request, CancellationToken cancellationToken)
        {
            Ping ping = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (ping == null)
                throw new NotFoundException(string.Format(MessagesResource.PingNotFound, request.Id));

            await _repository.DeleteAsync(ping, cancellationToken).ConfigureAwait(false);

            return true;
        }
    }
}
