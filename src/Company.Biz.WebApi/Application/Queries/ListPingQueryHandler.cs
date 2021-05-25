using AutoMapper;
using Company.Biz.Domain.Model;
using Company.Biz.Infrastructure.Abstractions;
using Company.Biz.WebApi.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Company.Biz.WebApi.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class ListPingQueryHandler : IRequestHandler<ListPingQuery, List<PingResponseVm>>
    {
        private readonly IPingRepository _pingRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pingRepository"></param>
        /// <param name="mapper"></param>
        public ListPingQueryHandler(IPingRepository pingRepository, IMapper mapper)
        {
            _pingRepository = pingRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<PingResponseVm>> Handle(ListPingQuery request, CancellationToken cancellationToken)
        {
            List<Ping> ping = await _pingRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);

            List<PingResponseVm> response = _mapper.Map<List<Ping>, List<PingResponseVm>>(ping);

            return response;
        }
    }
}
