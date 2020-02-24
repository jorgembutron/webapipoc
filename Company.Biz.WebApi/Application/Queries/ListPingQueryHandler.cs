using AutoMapper;
using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.WebApi.ViewModels;
using Company.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Queries
{
    public class ListPingQueryHandler : IRequestHandler<ListPingQuery, Response<List<PingResponseVm>>>
    {
        private readonly IPingRepository _pingRepository;
        private readonly IMapper _mapper;

        public ListPingQueryHandler(IPingRepository pingRepository, IMapper mapper)
        {
            _pingRepository = pingRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<PingResponseVm>>> Handle(ListPingQuery request, CancellationToken cancellationToken)
        {
            List<Ping> ping = await _pingRepository.GetAll(cancellationToken).ConfigureAwait(false);

            List<PingResponseVm> response = _mapper.Map<List<Ping>, List<PingResponseVm>>(ping);

            return new Response<List<PingResponseVm>>(Result.Ok) { Data = response };
        }
    }
}
