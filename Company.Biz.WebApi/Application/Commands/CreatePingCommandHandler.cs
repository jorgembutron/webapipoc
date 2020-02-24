using AutoMapper;
using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.WebApi.ViewModels;
using Company.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Commands
{
    public class CreatePingCommandHandler : IRequestHandler<CreatePingCommand, Response<PingResponseVm>>
    {
        private readonly IMapper _mapper;
        private readonly IPingRepository _repository;

        public CreatePingCommandHandler(IMapper mapper, IPingRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<PingResponseVm>> Handle(CreatePingCommand request, CancellationToken cancellationToken)
        {
            Ping ping = _mapper.Map<CreatePingCommand, Ping>(request);

            await _repository.AddAsync(ping, cancellationToken).ConfigureAwait(false);

            PingResponseVm vm = _mapper.Map<Ping, PingResponseVm>(ping);

            return new Response<PingResponseVm>(Result.Ok) { Data = vm };
        }
     
    }
}
