using AutoMapper;
using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.WebApi.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CreatePingCommandHandler : IRequestHandler<CreatePingCommand, PingResponseVm>
    {
        private readonly IMapper _mapper;
        private readonly IPingRepository _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="repository"></param>
        public CreatePingCommandHandler(IMapper mapper, IPingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PingResponseVm> Handle(CreatePingCommand request, CancellationToken cancellationToken)
        {
            Ping ping = _mapper.Map<CreatePingCommand, Ping>(request);

            await _repository.AddAsync(ping, cancellationToken).ConfigureAwait(false);

            PingResponseVm vm = _mapper.Map<Ping, PingResponseVm>(ping);

            return vm;
        }
     
    }
}
