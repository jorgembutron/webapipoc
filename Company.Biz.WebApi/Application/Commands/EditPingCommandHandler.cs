using System;
using System.Globalization;
using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.WebApi.Exceptions;
using Company.Biz.WebApi.Resources;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace Company.Biz.WebApi.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class EditPingCommandHandler : IRequestHandler<EditPingCommand, bool>
    {
        private readonly IPingRepository _repository;
        private readonly IStringLocalizer<MessagesResource> _localizer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public EditPingCommandHandler(IPingRepository repository, IStringLocalizer<MessagesResource> localizer)
        {
            _repository = repository;
            _localizer = localizer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(EditPingCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Current Culture: {CultureInfo.CurrentCulture}");
            Console.WriteLine($"Current UI Culture: {CultureInfo.CurrentUICulture}");

            Ping ping = await _repository.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);

            if (ping == null)
                throw new NotFoundException(string.Format(_localizer[MessagesResource.PingNotFound], request.Id));

            ping.Name = request.Name;

            await _repository.EditAsync(ping, cancellationToken).ConfigureAwait(false);

            return true;
        }


    }
}
