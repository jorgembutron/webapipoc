using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Company.Services.Exceptions;

namespace Company.Biz.WebApi.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class EditPingCommandHandler : IRequestHandler<EditPingCommand, Response>
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
        public async Task<Response> Handle(EditPingCommand request, CancellationToken cancellationToken)
        {
            Ping ping = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (ping == null)
                throw new NotFoundException($"Ping with Id: {request.Id}, not found.");

            ping.Name = request.Name;

            await _repository.EditAsync(ping, cancellationToken).ConfigureAwait(false);

            return new Response(Result.Ok);
        }
    }
}
