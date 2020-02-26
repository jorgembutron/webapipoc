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
    public class EditPingCommandHandler : IRequestHandler<EditPingCommand, bool>
    {
        private readonly IPingRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public EditPingCommandHandler(IPingRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(EditPingCommand request, CancellationToken cancellationToken)
        {
            Ping ping = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (ping == null)
                throw new NotFoundException(string.Format(Messages.PingNotFound, request.Id));

            ping.Name = request.Name;

            await _repository.EditAsync(ping, cancellationToken).ConfigureAwait(false);

            return true;
        }

       
    }
}
